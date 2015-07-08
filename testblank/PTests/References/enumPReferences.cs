using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.PTests.References
{
    /// <summary>
    /// Перечислитель характеристик. Номера могут не совпадать с номерами тестов
    /// </summary>
    public enum EnumPReferences
    {
        /// <summary>
        /// Характеристика проекта Управленец на основе методик кеттелла С и ПНН
        /// </summary>
        NoReference = -1,
        /// <summary>
        ///Характеристика на основе методики кеттелла С
        /// </summary>
        KettellC = 1,
        /// <summary>
        /// Характеристика на основе методики ПНН
        /// </summary>
        PNN = 2,
        /// <summary>
        /// Характеристика на основе методики адаптивность
        /// </summary>
        Adaptability = 3,
        /// <summary>
        /// Характеристика на основе методики FPI
        /// </summary>
        FPI = 4,
        /// <summary>
        /// Характеристика на основе методики кеттелла А
        /// </summary>
        KettellA = 5,
        /// <summary>
        /// Характеристика на основе методики Модуль
        /// </summary>
        Modul = 6,
        /// <summary>
        /// Интегральная характеристика на основе методики кеттелл С
        /// </summary>
        Integrative=7,
        /// <summary>
        /// Характеристика на основе методики прогноз 2
        /// </summary>
        Prognoz = 9,
        /// <summary>
        /// Характеристика на основе методики аддиктивная склонность
        /// </summary>
        Addictive = 10,
          /// <summary>
        /// Характеристика на основе методики Леонгарда
        /// </summary>
        Leongard = 11,
         /// <summary>
        /// Характеристика на основе методики НПН-А
        /// </summary>
        NPNA = 12
        
    }
}
