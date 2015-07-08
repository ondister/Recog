using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG6 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 3;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG6(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г6"; }
        }

        public string Description
        {
            get { return "«Циклотивный тип»"; }
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

            List<int> ansyes = new List<int>() { 6, 18, 28, 40, 50, 62, 72, 84 };
            List<int> ansno = new List<int>() {};
            _mark = LMarkExtractor.GetMark(_ge, _answers, ansyes, ansno)*KOOFICIENT;

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            _sten =(int) _mark;
        }

       public void GetLevel()
        {
            if (_sten <= 15) { _level = "Низкий"; }
            if (_sten >= 15 & _sten <= 18) { _level = "Средний"; }
            if (_sten >= 19) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Низкий") { _result = "Акцентуации черты характера не выявлено"; }
            if (_level == "Средний") { _result = "Имеется тенденция к акцентуации черты характера"; }
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Характеризуется сменой гипертимных и дистимных состояний. Им свойственны частые периодические смены настроения, а также зависимость от внешних событий. Радостные события вызывают у них картины гипертимии: жажда деятельности, повышенная говорливость, скачка идей; печальные — подавленность, замедленность реакций и мышления, так же часто меняется их манера общения с окружающими людьми. В подростковом возрасте можно обнаружить два варианта циклотимической акцентуации: типичные и лабильные циклоиды. Типичные циклоиды в детстве обычно производят впечатление гипертимных, но затем проявляется вялость, упадок сил, то что раньше давал ось легко, теперь требует непомерных усилий. Прежде шумные и бойкие, они становятся вялыми домоседами, наблюдается падение аппетита, бессонница или, наоборот, сонливость. На замечания реагируют раздражением, даже грубостью и гневом, в глубине души, однако, впадая при этом в уныние, глубокую депрессию, не исключены суицидальные попытки. Учатся неровно, случившиеся упущения наверстывают с трудом, порождают в себе отвращение к занятиям. У лабильных циклоидов фазы смены настроения обычно короче, чем у типичных циклоидов. Плохие дни отмечаются более насыщенными дурным настроением, чем вялостью. В период подъема выражены желания иметь друзей, быть в компании. Настроение влияет на самооценку. "; }
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
