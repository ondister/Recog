using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.PTests.References
{
    /// <summary>
    /// класс для вынесения заключения по характеристике управленец
    /// </summary>
  public  class ConclusionMaster
    {
        private string _r;
        private string _summary;

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        public string R
        {
            get { return _r; }
            set { _r = value; }
        }

      public void GetConclusion(Kettell.KettellCTestReport kr,PNN.PNNTestReport pr)
      {
          bool _hasresult = false;
          List<bool> maintrues = new List<bool>();
          List<bool> advansedtrues = new List<bool>();
          List<bool> lasttrues = new List<bool>();

          maintrues.Add(ScaleChecker.MarkInRange(kr.ListScales[10], 0, 6));
          maintrues.Add(ScaleChecker.MarkInRange(kr.ListScales[6], 7, 12));
          maintrues.Add(ScaleChecker.MarkInRange(kr.ListScales[15], 7, 12));
          maintrues.Add(ScaleChecker.MarkInRange(kr.ListScales[3], 7, 12));
          int _countmain = maintrues.Count(t => t == true);

          advansedtrues.Add(ScaleChecker.MarkInRange(kr.ListScales[2], 4, 8));
          advansedtrues.Add(ScaleChecker.MarkInRange(kr.ListScales[4], 6, 12));
          advansedtrues.Add(ScaleChecker.MarkInRange(kr.ListScales[7], 6, 12));
          advansedtrues.Add(ScaleChecker.MarkInRange(kr.ListScales[11], 6, 12));
          advansedtrues.Add(ScaleChecker.MarkInRange(kr.ListScales[13], 7, 12));
          advansedtrues.Add(ScaleChecker.MarkInRange(kr.ListScales[14], 6, 12));
          int _countadvansed = advansedtrues.Count(t => t == true);

          lasttrues.Add(ScaleChecker.MarkInRange(kr.ListScales[9], 0, 5));
          lasttrues.Add(ScaleChecker.MarkInRange(kr.ListScales[16], 0, 7));
          int _countlast = lasttrues.Count(t => t == true);


          if (_countmain==4 & (_countadvansed + _countlast) >= 4 & ScaleChecker.HasLowLevel(pr.ListScales[0]) == false)
          {
              R1();_hasresult=true;
          }

          if (_countmain == 4 & (_countadvansed + _countlast) <= 3 & ScaleChecker.HasLowLevel(pr.ListScales[0]) == false)
          {
              RK(); _hasresult = true;
          }

          if (_countmain == 3 & (_countadvansed + _countlast) >= 4 & ScaleChecker.HasLowLevel(pr.ListScales[0]) == false)
          {
              RK(); _hasresult = true;
          }

          if (_countmain == 3 & (_countadvansed + _countlast) <=3 & ScaleChecker.HasLowLevel(pr.ListScales[0]) == true)
          {
              RU(); _hasresult = true;
          }

          if (_countmain == 2 & (_countadvansed + _countlast) >=4 & ScaleChecker.HasLowLevel(pr.ListScales[0]) == true)
          {
              RU(); _hasresult = true;
          }
          
          if (_hasresult==false)
          {
          NR();
          }

      }
      private void R1()
      {
          _r = "Рекомендуется в первую очередь";
          _summary = "В полной мере соответствует требованиям должности. " + _r + " к назначению на высшую должность.";
      }
      private void RK()
      {
          _r = "Рекомендуется";
          _summary = "В основном соответствует требованиям должности. " + _r + " к назначению на высшую должность.";
      }
      private void RU()
      {
          _r = "Рекомендуется условно";
          _summary = "Не в полной мере соответствует требованиям должности. " + _r + " к назначению на высшую должность.";
      }
      private void NR()
      {
          _r = "Не рекомендуется";
          _summary = "Не соответствует требованиям должности. " + _r + " к назначению на высшую должность.";
      }
  
  }
}
