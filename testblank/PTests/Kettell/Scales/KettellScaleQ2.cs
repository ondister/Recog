using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleQ2 : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private double _x;

        public double X
        {
            get { return _x; }
        }
        private KettellAnswers _answers;
        private pBaseEntities _ge;
        private EnumKettellType _ktype;
        public KettellScaleQ2(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор Q2"; }
        }

        public string Description
        {
            get { return "«конформизм – нонконформизм»"; }
        }

        public double Mark
        {
            get 
            {
                 
                return _mark;
            }
            set { _mark = value;   }
        }

        public int Stens
        {
            get {
                 
                return _sten;
            }
            set { _sten = value; }
        }
        public string Level
        {
             
            get {
                 
                return _level;
            }
        }

        public string ResultDescription
        {
            get 
            {
                 
                return _result;
            }
        }

        public void GetMark()
        {

         List<int> ans;
         if (_ktype == EnumKettellType.CForm)
         {
             ans = new List<int>();
             for (int i = 15; i <= 100; i += 17)
             {
                 ans.Add(i);
             }
         }
         else
         {
             ans = new List<int>() { 22, 47, 71, 72, 96, 97, 121, 122, 146, 171 };
         }
            _mark = KettellMarkExtractor.GetMark(_ge, _answers, ans, _ktype);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if (_ktype == EnumKettellType.CForm)
            {
            if ( _mark <= 2) { _sten = 1; }
            if (_mark ==3) { _sten = 2; }
            if (_mark ==4) { _sten = 4; }
            if (_mark ==5) { _sten = 5; }
            if (_mark ==6) { _sten = 6; }
            if (_mark ==7) { _sten = 7; }
            if (_mark ==8) { _sten = 8; }
            if (_mark ==9) { _sten = 9; }
            if (_mark >=10) { _sten = 10; }
            }
            else
            {
                if (_mark <= 3) { _sten = 1; }
                if (_mark ==4) { _sten = 2; }
                if (_mark >= 5 & _mark <= 6) { _sten = 3; }
                if (_mark ==7) { _sten = 4; }
                if (_mark >= 8 & _mark <= 9) { _sten = 5; }
                if (_mark >= 10 & _mark <= 11) { _sten = 6; }
                if (_mark >= 12 & _mark <= 13) { _sten = 7; }
                if (_mark >= 14 & _mark <= 15) { _sten = 8; }
                if (_mark >= 16 & _mark <= 17) { _sten = 9; }
                if (_mark >= 18 & _mark <= 20) { _sten = 10; }
            }
        }

       public void GetLevel()
        {
            if (_ktype == EnumKettellType.CForm)
            {
                if (_sten >= 1 & _sten <= 3) { _level = "Низкий"; }
                if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
                if (_sten >= 7 & _sten <= 10) { _level = "Высокий"; }
            }
            else
            {
                if (_sten <= 5.5) { _level = "Низкий"; }
                else { _level = "Высокий"; }
            }
        }
        public void GetResult()
        {
            if (_sten >= 1 & _sten <= 3) { _result = "Предпочитает работать и принимать решения вместе с другими людьми, любит общение и восхищение, зависит от них. Склонен идти с группой. Необязательно общителен, скорее ему нужна поддержка со стороны группы."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Зависит от группы, «присоединяющийся», ведомый, идущий на зов группы (групповая зависимость)."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Самоудовлетворенный, предлагающий собственное решение, предприимчивый."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Независим, склонен идти собственной дорогой, принимать собственные решения, действовать самостоятельно. Он не считается с общественным мнением, но не обязательно играет доминирующую роль в отношении других. Нельзя считать, что люди ему не нравятся, он просто не нуждается в их согласии и поддержке."; }

        }
        public void GetX()
        {

            if (_ktype == EnumKettellType.AForm)
            {

                if (_mark <= 2) { _x = 0.60; }
                if (_mark == 3) { _x = 0.54; }
                if (_mark == 4) { _x = 0.48; }
                if (_mark == 5) { _x = 0.42; }
                if (_mark == 6) { _x = 0.36; }
                if (_mark == 7) { _x = 0.30; }
                if (_mark == 8) { _x = 0.24; }
                if (_mark == 9) { _x = 0.18; }
                if (_mark == 10) { _x = 0.12; }
                if (_mark >= 11) { _x = 0.06; }
            }
        }


        public List<string> MultiResult
        {
            get { throw new NotImplementedException(); }
        }

        public void GetMultiResult()
        {
            throw new NotImplementedException();
        }
    }
}
