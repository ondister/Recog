using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Recog.Data;
using Recog.Humans;
using System.Data.Objects;
using System.Collections;

namespace Recog.Controls
{
    public partial class HumanControl : UserControl
    {
        private List<Control> _controls;
        private string _firstname;
        private string _secondname;
        private string _lastname;
        private string _additinfo;
        private DateTime? _birthday = null;
        private int _educationid=0;
        private int _genderid=0;
        private int _departmentid=0;
        private int _id=0;
        private fBaseEntities _fe = null;
        
               
        
        public int DepartmentID
        {
            get
            {
                if (this._fe != null)
                {
                    _departmentid = (int)this.cb_department.SelectedValue;
                }
                return _departmentid;
            }
            set { _departmentid = value; this.cb_department.SelectedValue = _departmentid; }
        }



        public string FirstName
        {
            get
            {
                _firstname = this.tb_firstname.Text.ToUpper();
                return _firstname;
            }
            set { _firstname = value; this.tb_firstname.Text = _firstname; }
        }


        public string SecondName
        {
            get
            {
                _secondname = this.tb_secondname.Text.ToUpper();
                return _secondname;
            }
            set { _secondname = value; this.tb_secondname.Text = _secondname; }
        }


        public string LastName
        {
            get
            {
                _lastname = this.tb_lastname.Text.ToUpper();
                return _lastname;
            }
            set { _lastname = value; this.tb_lastname.Text = _lastname; }
        }

        public string AdditionalInfo
        {
            get 
            {
                _additinfo = this.tb_additinfo.Text.ToUpper();
                return _additinfo;
            }
            set { _additinfo = value; this.tb_additinfo.Text = _additinfo; }
        }

        public DateTime? BirthDay
        {
            get
            {
                _birthday = this.dp_birthdate.Value;
                return _birthday;
            }
            set
            {
                _birthday = value;
                if (_birthday.HasValue == false) { this.dp_birthdate.Value = DateTime.Now.Date; }
                else
                {
                    this.dp_birthdate.Value = _birthday.Value;
                }
            }
        }


        public int EducationID
        {
            get
            {
                if (this._fe != null)
                {
                    _educationid = (int)this.cb_education.SelectedValue;
                }
                return _educationid;
            }
            set { _educationid = value; this.cb_education.SelectedValue = _educationid; }
        }


       
        public int GenderID
        {
            get {
                if (this._fe != null)
                {
                    _genderid = (int)this.cb_gender.SelectedValue;
                }
                return _genderid; }
            set { _genderid = value; this.cb_gender.SelectedValue = _genderid; }
        }


        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                try
                {
                    if (_fe != null)
                    {
                        human fhuman = _fe.humans.First(h => h.idh == _id);
                        this.FirstName = fhuman.firstname;
                        this.SecondName = fhuman.secondname;
                        this.LastName = fhuman.lastname;
                        this.BirthDay = fhuman.birthday;
                        this.AdditionalInfo = fhuman.additinfo;

                        this.cb_education.SelectedValue = fhuman.educationid;
                        this.cb_gender.SelectedValue = fhuman.genderid;
                        this.cb_department.SelectedValue = fhuman.departmentid;
                    }
                }
                catch (InvalidOperationException)
                {
                    this.FirstName = string.Empty;
                    this.SecondName = string.Empty;
                    this.LastName = string.Empty;
                    this.BirthDay = null;
                    this.AdditionalInfo = string.Empty;
                    this.cb_education.SelectedValue = 6;
                    this.cb_gender.SelectedValue = 3;
                    this.cb_department.SelectedValue = 1;
                }
            }
        }


        public HumanControl()
        {
            InitializeComponent();
        }
        public void RequeryData()
        { 
        
        }
        private void HumanControl_Load(object sender, EventArgs e)
        {
            _birthday = DateTime.Now.Date;
            _controls = new List<Control>();
            _controls.Add(tb_secondname);
            _controls.Add(tb_firstname);
            _controls.Add(tb_lastname);
            _controls.Add(dp_birthdate);
            _controls.Add(cb_gender);
            _controls.Add(cb_education);
            _controls.Add(cb_department);
            _controls.Add(tb_additinfo);
        }

        public void ConnectToBase(fBaseEntities fe)
        {
            _fe = fe;

            if (_fe != null)
            {
                this.cb_gender.DataSource = _fe.gensers;
                this.cb_gender.DisplayMember = "description";
                this.cb_gender.ValueMember = "idg";

                this.cb_education.DataSource = _fe.educations;
                this.cb_education.DisplayMember = "description";
                this.cb_education.ValueMember = "ide";

                this.RefreshDeps();
            
            }
        }

      

        public void AddHuman()
        {
            if (this.FindHuman() != true)
            {
                if (_fe != null)
                {
                    human h = human.Createhuman(0, this.SecondName);
                    h.firstname = this.FirstName;
                    h.lastname = this.LastName;
                    h.birthday = this.BirthDay;
                    h.additinfo = this.AdditionalInfo;
                    h.educationid = this.EducationID;
                    h.genderid = this.GenderID;
                    h.departmentid = this.DepartmentID;
                    _fe.humans.AddObject(h);
                    _fe.SaveChanges();
                }
            }
            else { MessageBox.Show("Похоже, что такой человек с такой фамилией, именем, отчеством и днем рождения есть в базе"); }

        }

        public void EditHuman()
        {

            try
            {
                if (_fe != null)
                {
                    human h = _fe.humans.First(hu => hu.idh == this._id);

                    h.firstname = this.FirstName;
                    h.secondname = this.SecondName; 
                    h.lastname = this.LastName; 
                    h.additinfo = this.AdditionalInfo; 
                    h.birthday = this.BirthDay; 
                    h.educationid = this.EducationID; 
                    h.genderid = this.GenderID; 
                    h.departmentid = this.DepartmentID;
                    _fe.SaveChanges();
                }
            }
            catch (InvalidOperationException)
            { MessageBox.Show("Человека с указанным id в базе нет"); }

        }
        public void DeleteHuman()
        {
            try
            {
                if (_fe != null)
                {
                    human h = _fe.humans.First(hu => hu.idh == this.Id);
                    if (MessageBox.Show("Вы действительно хотите удалить этого замечательного человека со всеми результатами тестов???", "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        h.testresults.Load();
                        _fe.humans.DeleteObject(h);
                        _fe.SaveChanges();
                    }
                }
            }
            catch (InvalidOperationException)
            { MessageBox.Show("Человека с указанным id в базе нет"); }
        }

        private bool HumanIsExist(human h)
        {

            if (h.firstname == this.FirstName & h.secondname == this.SecondName & h.lastname == this.LastName & h.birthday == this.BirthDay) { return true; }
            else { return false; }
        }

        private bool FindHuman()
        {
            bool isex = false;
            if (_fe != null)
            {
                IEnumerable<human> humans = _fe.humans.Where(HumanIsExist);

                if (humans.Count() != 0) { isex = true; }
            }
            return isex;

        }

        private void c_KeyDown(object sender, KeyEventArgs e)
        {
            Control c=(Control)sender;
            if (e.KeyCode == Keys.Enter )
            {
                
                for (int i=0;i<_controls.Count;i++)
                {
                    Control cc=_controls[i];
                    if (c == cc& i!= _controls.Count-1) { _controls[i+1].Focus(); break; }
                }
            }
        }

        private void btn_addep_Click(object sender, EventArgs e)
        {
            FormDep frmdep = new FormDep(_fe);
            frmdep.Show(this);
            frmdep.FormClosed += new FormClosedEventHandler(frmdep_FormClosed);
        }

        void frmdep_FormClosed(object sender, FormClosedEventArgs e)
        {

            RefreshDeps();
        }

        
       public void RefreshDeps()
       {
           ArrayList deps = new ArrayList();
           foreach( department d in _fe.departments )
           {
           deps.Add(d);
       }
           this.cb_department.DataSource = null;
           this.cb_department.DataSource = deps;
            this.cb_department.DisplayMember = "description";
            this.cb_department.ValueMember = "idd";
       }

       

       

       
    }
}
