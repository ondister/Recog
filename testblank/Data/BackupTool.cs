using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Recog.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
namespace Recog.Data
{
    public class BackupTool
    {
        private DirectoryInfo _savePath;
        private DirectoryInfo _restorePath;
        private List<human> _humans;

      
        private List<department> _departmens;
        private fBaseEntities _fe;

        public event EventHandler HumanDone;
        private EventArgs arg;
        private void OnHumanDone() { if (HumanDone != null) { HumanDone(this, arg); } }

        public List<human> Humans
        {
            get { return _humans; }
        }

        public DirectoryInfo RestorePath
        {
            get { return _restorePath; }
        }

        public DirectoryInfo SavePath
        {
            get { return _savePath; }
        }

        public BackupTool(fBaseEntities fe)
        {
            _fe = fe;
            arg = new EventArgs();
            _humans = new List<human>();
        }

        private void Save<T>(T entity, string filename) where T : EntityObject
        {
            if (_savePath!=null)
            {
                FileStream stream = new FileStream(_savePath.FullName + @"\" + filename + ".rbk", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, entity);
                stream.Close();
            }
        }

        private T Restore<T>(string filename) where T: EntityObject
        {
            try
            {
                FileStream stream = File.OpenRead(_restorePath.FullName + @"\" + filename);

                BinaryFormatter formatter = new BinaryFormatter();
                T newobj = (T)formatter.Deserialize(stream);
                stream.Close();
                return newobj;

            }
            catch (InvalidCastException)
            {

                return default(T);
            }
        }

        private void SaveServiseEntities()
        {
            foreach (department _department in _fe.departments)
            {
                this.Save<department>(_department, _department.GetHashCode().ToString());
            }
        }

        public void SetSavePath(string savePath)
        {
            if (Directory.Exists(savePath) == true)
            {
                _savePath = Directory.CreateDirectory(savePath + @"\RecogBackup_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString());
            }
            else
            {
                _savePath = Directory.CreateDirectory(Environment.SpecialFolder.MyDocuments.ToString() + @"\RecogBackup_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString());
            }
        }

        public bool CheckRestorePath(string restorePath)
        {
            bool pathisexists = false;
            bool humansisexists = false;
            bool departmentisexists = false;
            if (Directory.Exists(restorePath) == true)
            {
                pathisexists = true;
                _restorePath = new DirectoryInfo(restorePath);
                _humans = new List<human>();
                _departmens = new List<department>();
                FileInfo[] files = _restorePath.GetFiles("*.rbk");
                if (files.Length != 0)
                {
                    for (int fileindex = 0; fileindex < files.Length; fileindex++)
                    {
                        human _human = this.Restore<human>(files[fileindex].Name);
                     
                        if (_human != null)
                        {
                            _humans.Add(_human);
                            humansisexists = true;
                            
                        }
                        else
                        {
                            department _department = this.Restore<department>(files[fileindex].Name);
                            if (_department != null)
                            {
                                _departmens.Add(_department);
                                departmentisexists = true;

                            }
                        }

                    }
                }
            }

            return pathisexists & humansisexists & departmentisexists;
        }

        public void Save(List<human> humans)
        {
        
            this.SaveServiseEntities();
            _humans = humans;
            foreach (human _human in humans)
            {
                _human.testresults.Load();
                this.Save<human>(_human, _human.GetHashCode().ToString());
                OnHumanDone();
              
            }
        }

        public bool Restore(string restorePath)
        {
            bool issucsess = false;
            if (this.CheckRestorePath(restorePath) == true)
            {
                foreach (human _human in _humans)
                {
                    this.RestoreHuman(_human);
                    OnHumanDone();
                }

                issucsess = true;
            }
            return issucsess;
        }
        
        private void RestoreHuman(human newhuman)
        {
            human oldhuman=_fe.humans.FirstOrDefault(human => human.firstname == newhuman.firstname &
                            human.secondname == newhuman.secondname &
                            human.lastname == newhuman.lastname);
            if ( oldhuman== null)
            {
                this.AddHuman(newhuman);
            }
            else
            {
                this.UpgradeHuman(oldhuman, newhuman);
            }
        }

        private int AddDepartment(department newdepartment)
        {
            department newdep = department.Createdepartment(0, newdepartment.description);
            _fe.departments.AddObject(newdep);
            _fe.SaveChanges();
            return newdep.idd;
        }

        private void AddHuman(human newhuman)
        {
            int newdepartmentid;
            department newdep=_departmens.FirstOrDefault(ndep => ndep.idd == (int)newhuman.departmentid);
            department basedep=_fe.departments.FirstOrDefault(dep => dep.description == newdep.description);
            if (basedep == null)
            {
                newdepartmentid = this.AddDepartment(_departmens.First(dep => dep.idd == newhuman.departmentid));
            }
            else
            { newdepartmentid = basedep.idd; }

            human createdhuman = human.Createhuman(0, newhuman.secondname);
            createdhuman.additinfo = newhuman.additinfo;
            createdhuman.birthday = newhuman.birthday;
            createdhuman.departmentid = newdepartmentid;
            createdhuman.educationid = newhuman.educationid;
            createdhuman.firstname = newhuman.firstname;
            createdhuman.genderid = newhuman.genderid;
            createdhuman.lastname = newhuman.lastname;

           
            foreach (testresult tresult in newhuman.testresults)
            {
                testresult createdtresult = testresult.Createtestresult(0, createdhuman.idh, tresult.testdate, tresult.testid, tresult.teststream, tresult.mode);
                createdhuman.testresults.Add(createdtresult);
            }
            _fe.humans.AddObject(createdhuman);
            _fe.SaveChanges();
        }

        private void UpgradeHuman(human oldhuman, human newhuman)
        {
            foreach (testresult tresult in newhuman.testresults)
            {
                if(oldhuman.testresults.FirstOrDefault(oldrestest=>oldrestest.testid==tresult.testid & oldrestest.testdate==tresult.testdate)==null)
                {
                testresult createdtresult = testresult.Createtestresult(0, oldhuman.idh, tresult.testdate, tresult.testid, tresult.teststream, tresult.mode);
                oldhuman.testresults.Add(createdtresult);
                _fe.SaveChanges();
                }
            }  
        }
    }
}
