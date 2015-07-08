using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.PTests;
using Recog.Data;
using Recog.PTests.ResultReader;
using System.ComponentModel;

namespace Recog.Interact
{
  public  class ExcelReport
    {
      private RExcel _exapp;
      private pBaseEntities _ge;
      private fBaseEntities _fe;
      private EnumPTests _test;
     private  DateTime _mindate;
     private DateTime _maxdate;
      private BackgroundWorker _worker;

      public BackgroundWorker Worker
      {
          get { return _worker; }
      }

      public ExcelReport(pBaseEntities ge, fBaseEntities fe,EnumPTests test)
      {
          _ge = ge;
          _fe = fe;
          _test = test;
          _worker= new BackgroundWorker();
          _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
          _worker.WorkerReportsProgress = true;
          _worker.WorkerSupportsCancellation = true;
      }

     

      void _worker_DoWork(object sender, DoWorkEventArgs e)
      {
          this.Create();
      }

      public void Create(DateTime mindate, DateTime maxdate)
      {
          _mindate = mindate;
          _maxdate = maxdate;
          _worker.RunWorkerAsync();
      }

      private void Create()
      {
          _exapp = new RExcel();
          _exapp.Visible = false;
          _exapp.NewDocument();
         
          try
          {
              int tstcnt = 0;
              int rowindex = 2;
              //проходим по всем тестам всех людей
              foreach (human h in _fe.humans)
              {
                  if (_worker.CancellationPending == true) { break; }
                  h.testresults.Load();
                  var tp = h.testresults.Where(t => t.testid == (int)_test & t.testdate >= _mindate & t.testdate <= _maxdate);
                  foreach (testresult t in tp)
                  {
                      if (_worker.CancellationPending == true) { break; }
                      
                      ITestReport report = ReportFactory.CreateReport(_test, h, t, _ge, _fe, false);
                      _exapp.SetCellValue(rowindex, 1, rowindex - 1);
                      //добавление фамилии
                      _exapp.SetCellValue(rowindex, 2, h.secondname);
                      _exapp.SetCellValue(rowindex, 3, h.firstname);
                      _exapp.SetCellValue(rowindex, 4, h.lastname);
                      //добавление даты теста
                      _exapp.SetCellValue(rowindex, 5, t.testdate);
                      _exapp.SetCellValue(rowindex, 6, h.birthday);
                      _exapp.SetCellValue(rowindex, 7, ((t.testdate.Date - h.birthday.Value.Date).Days / 365));
                      _exapp.SetCellValue(rowindex, 8, _fe.educations.First(e => e.ide == h.educationid).description);
                      _exapp.SetCellValue(rowindex, 9, _fe.gensers.First(e => e.idg == h.genderid).description);
                      _exapp.SetCellValue(rowindex, 10, _fe.rancs.First(e => e.idr == h.rankid).description);
                      _exapp.SetCellValue(rowindex, 11, _fe.departments.First(e => e.idd == h.departmentid).description);

                      int colindex = 12;
                      int scalescount = report.ListScales.Count;
                      for (int scaleindex = 0; scaleindex < scalescount; scaleindex++)
                      {
                          report.ListScales[scaleindex].GetMark();
                          _exapp.SetCellValue(1, colindex + scaleindex, report.ListScales[scaleindex].Name + "(СБ)");
                          _exapp.SetCellValue(rowindex, colindex + scaleindex, report.ListScales[scaleindex].Mark);
                          _exapp.SetCellValue(1, colindex + scaleindex + scalescount, report.ListScales[scaleindex].Name + "(СТ)");
                          _exapp.SetCellValue(rowindex, colindex + scaleindex + scalescount, report.ListScales[scaleindex].Stens);

                      }

                      rowindex++;
                      tstcnt++;
                      _worker.ReportProgress(tstcnt);

                  }
              }
          }
          catch(Exception ex)
          {
              _exapp.Visible = true;
              throw new Exception(ex.Message);
          }
          _exapp.Visible = true;

      }

      public int FindTestsCount()
      {

          return _fe.testresults.Count(t => t.testid == (int)_test);
      }

      public int FindTestsCount(DateTime mindate, DateTime maxdate)
      {
      
          return  _fe.testresults.Count(t => t.testid == (int)_test & t.testdate >= mindate & t.testdate <= maxdate);
      }

      public DateTime FindMinDate()
      {
          DateTime date = DateTime.MinValue;
          if (FindTestsCount() != 0)
          {
              var tr = _fe.testresults.Where(t => t.testid == (int)_test);
              date= tr.Min(d => d.testdate);
          }
          return date;
      }
      public DateTime FindMaxDate()
      {
          DateTime date = DateTime.MaxValue;
          if (FindTestsCount() != 0)
          {
          var tr = _fe.testresults.Where(t => t.testid == (int)_test);
         date= tr.Max(d => d.testdate);
          }
          return date;
      }


    }
}
