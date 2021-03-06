﻿using System;
using System.Collections.Generic;
using Recog.Data;
namespace Recog.PTests.MD.Scales
{

    public class MDScaleM3 : IScale
    {
        private double _mark;
        private int _sten;

        private string _result;
        private string _level;
        private MDAnswers _answers;
        private pBaseEntities _ge;
        List<int> _ans;
        private List<string> _multiresult;
        public MDScaleM3(MDAnswers mdAnswers, pBaseEntities GlobalEntities)
        {
            _answers = mdAnswers;
            _ge = GlobalEntities;

        }
        public string Name
        {
            get { return "Модуль3"; }
        }

        public string Description
        {
            get { return "«Расстройства личности и поведения у взрослых»"; }
        }

        public double Mark
        {
            get
            {

                return _mark;
            }
            set { _mark = value; }
        }

        public int Stens
        {
            get
            {
                return _sten;
            }
            set { _sten = value; }
        }
        public string Level
        {

            get
            {

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

            _ans = new List<int>() {2,8,12,16,20,24,26,27,28,29,31,37,38,42,43,46,47,51,56,58,62,64,68,71,73,79,85,86,91,96,106,112,116,117,123,129,132,137,138,141,145,149,154,155,159,160,166,175,183,198,200,212,216,225,228};
            _mark = MDMarkExtractor.GetMark(_ge, _answers, _ans);
            this.GetSten();
            this.GetLevel();
            this.GetResult();
            this.GetMultiResult();

        }

        public void GetSten()
        {
            
                if (_mark >= 35) { _sten = 1; }
                if (_mark <= 34 & _mark >= 30) { _sten = 2; }
                if (_mark <= 29 & _mark >= 25) { _sten = 3; }
                if (_mark <= 24 & _mark >= 20) { _sten = 4; }
                if (_mark <= 19 & _mark >= 15) { _sten = 5; }
                if (_mark <= 14 & _mark >= 10) { _sten = 6; }
                if (_mark <= 9 & _mark >= 7) { _sten = 7; }
                if (_mark <= 6 & _mark >= 2) { _sten = 8; }
                if (_mark == 1) { _sten = 9; }
                if (_mark == 0) { _sten = 10; }
           
        }

        public void GetLevel()
        {
            if (_sten >= 1 & _sten <= 3) { _level = "Неудовлетворительный уровень НПУ"; }
            if (_sten >= 4 & _sten <= 5) { _level = "Удовлетворительный уровень НПУ"; }
            if (_sten >= 6 & _sten <= 8) { _level = "Хороший уровень НПУ"; }
            if (_sten >= 9 & _sten <= 10) { _level = "Высокий уровень НПУ"; }

        }
        public void GetResult()
        {
            _result += "Симптомы, выявляемые с помощью данного модуля, отражают расстройства личности и поведения у взрослых, что соответствуют психопатиям.";
            if (_sten >= 1 & _sten <= 3) { _result = "По результатам обследования по модулю М3 у респондента выявлены отчетливые признаки нервно-психической неустойчивости. Симптомы, выявляемые с помощью модуля М3 отражают расстройства зрелой личности и поведения у взрослых, что соответствуют психопатиям. Под психопатиями понимается аномальная структура личности с эмоционально-волевыми и мыслительными нарушениями и аномальными типами реагирования на стрессовые ситуации. Характерными признаками психопатий являются следующие: при сохраненном интеллекте, у индивида снижена критика к себе и своему поведению; плохо используется жизненный опыт; недостаточно прогнозируются последствия поступков и деятельности завышенный уровень притязаний; сила ответной реакции превышает силу раздражителя. Диагноз психопатий может быть установлен только после 25 лет. До этого возраста используется заключение: «транзиторные расстройства личности» (по В.В. Нечипоренко, 1995). У лиц данной группы НПУ имеет место высокая склонность к девиантному поведению, совершению непрогнозируемых действий, поэтому превышение показателей по данному модулю требует сбора анамнестических данных, подтверждающих нарушения социального взаимодействия, совершение асоциальных поступков. Данные лица требуют дополнительного контроля поведения (поведение практически не поддаётся коррекции), могут негативно влиять на климат в коллективе, совершать асоциальные поступки, склонны к зависимым формам поведения (алкоголь, наркотики, азартные игры). Характеризуются такими личностными особенностями как инфантильность, ригидность, злопамятность, мстительность, импульсивность, некомформность. "; }
            if (_sten >= 4 & _sten <= 5) { _result = "По результатам обследования по модулю М3 у респондента выявлены отдельные признаки нервно-психической неустойчивости. Лица с психопатиями (или транзиторными расстройствами личности) ограниченно годны (не годны) к экстремальным видам деятельности в зависимости от степени декомпенсации психического состояния. Для подтверждения данного расстройства требуется подробный сбор анамнестических данных и дополнительные методы исследований. Для лиц с превышением показателей по модулю МЗ характерны: многочисленные и многоплановые нарушения в сфере социального взаимодействия, высокая склонность к девиантным формам поведения, совершению непрогнозируемых действий. Такие лица требуют постоянного контроля поведения (поведение практически не поддается коррекции), могут негативно влиять на климат в коллективе, совершать асоциальные и антисоциальные поступки, склонны к зависимым формам поведения (алкоголь, наркотики, азартные игры). Зачастую лица с превышением показателей по модулю МЗ характеризуются такими личностными особенностями как: инфантильность, ригидность, злопамятность, мстительность, импульсивность, нонкомформность. "; }
            if (_sten >= 6 & _sten <= 8) { _result = "Хороший уровень нервно-психической устойчивости. Характерологических особенностей, достигших уровня акцентуаций не выявлено. Признаки пограничных психических расстройств и психопатологической симптоматики на момент обследования отсутствуют. Прогнозируемый риск дезадаптационных нарушений минимальный."; }
            if (_sten == 9) { _result = "Психопатологическая симптоматика не выявлена. На момент обследования - полное отсутствие признаков акцентуаций характера и признаков пограничных психических расстройств."; }
        }

        public List<string> MultiResult
        {
            get { return _multiresult; }
        }

        public void GetMultiResult()
        {
            _multiresult = new List<string>();
            _multiresult.Add( "Симптомы, выявляемые с помощью данного модуля, отражают расстройства личности и поведения у взрослых, что соответствуют психопатиям.");
            if (_sten >= 1 & _sten <= 3) { _multiresult.Add( "По результатам обследования по модулю М3 у респондента выявлены отчетливые признаки нервно-психической неустойчивости. Симптомы, выявляемые с помощью модуля М3 отражают расстройства зрелой личности и поведения у взрослых, что соответствуют психопатиям. Под психопатиями понимается аномальная структура личности с эмоционально-волевыми и мыслительными нарушениями и аномальными типами реагирования на стрессовые ситуации. Характерными признаками психопатий являются следующие: при сохраненном интеллекте, у индивида снижена критика к себе и своему поведению; плохо используется жизненный опыт; недостаточно прогнозируются последствия поступков и деятельности завышенный уровень притязаний; сила ответной реакции превышает силу раздражителя. Диагноз психопатий может быть установлен только после 25 лет. До этого возраста используется заключение: «транзиторные расстройства личности» (по В.В. Нечипоренко, 1995). У лиц данной группы НПУ имеет место высокая склонность к девиантному поведению, совершению непрогнозируемых действий, поэтому превышение показателей по данному модулю требует сбора анамнестических данных, подтверждающих нарушения социального взаимодействия, совершение асоциальных поступков. Данные лица требуют дополнительного контроля поведения (поведение практически не поддаётся коррекции), могут негативно влиять на климат в коллективе, совершать асоциальные поступки, склонны к зависимым формам поведения (алкоголь, наркотики, азартные игры). Характеризуются такими личностными особенностями как инфантильность, ригидность, злопамятность, мстительность, импульсивность, некомформность. "); }
            if (_sten >= 4 & _sten <= 5) { _multiresult.Add( "По результатам обследования по модулю М3 у респондента выявлены отдельные признаки нервно-психической неустойчивости. Лица с психопатиями (или транзиторными расстройствами личности) ограниченно годны (не годны) к экстремальным видам деятельности в зависимости от степени декомпенсации психического состояния. Для подтверждения данного расстройства требуется подробный сбор анамнестических данных и дополнительные методы исследований. Для лиц с превышением показателей по модулю МЗ характерны: многочисленные и многоплановые нарушения в сфере социального взаимодействия, высокая склонность к девиантным формам поведения, совершению непрогнозируемых действий. Такие лица требуют постоянного контроля поведения (поведение практически не поддается коррекции), могут негативно влиять на климат в коллективе, совершать асоциальные и антисоциальные поступки, склонны к зависимым формам поведения (алкоголь, наркотики, азартные игры). Зачастую лица с превышением показателей по модулю МЗ характеризуются такими личностными особенностями как: инфантильность, ригидность, злопамятность, мстительность, импульсивность, нонкомформность. "); }
            if (_sten >= 6 & _sten <= 8) { _multiresult.Add( "Хороший уровень нервно-психической устойчивости. Характерологических особенностей, достигших уровня акцентуаций не выявлено. Признаки пограничных психических расстройств и психопатологической симптоматики на момент обследования отсутствуют. Прогнозируемый риск дезадаптационных нарушений минимальный."); }
            if (_sten == 9) { _multiresult.Add( "Психопатологическая симптоматика не выявлена. На момент обследования - полное отсутствие признаков акцентуаций характера и признаков пограничных психических расстройств."); }
        }
    }
}
