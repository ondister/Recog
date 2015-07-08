using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.RecogCore;
using System.Drawing;
namespace Recog.RecogCore.AnswerGrid
{
    /// <summary>
    /// Инкапсулирует грид ответов для распознавания бланка
    /// </summary>
  public  class Grid
    {
        private Answers _answers;
       
        /// <summary>
        /// Возвращает и получает коллекцию ответов
        /// </summary>
        /// <value>
        /// Коллекция ответов
        /// </value>
        public Answers Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }



        /// <summary>
        /// Инициализирует новый грид с ответами на основе класса грид
        ///  </summary>
        
      public Grid()
      {
          _answers = new Answers();
      }

      

    }
}
