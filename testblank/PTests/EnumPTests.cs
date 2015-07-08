using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.PTests
{
    /// <summary>
    /// Перечислитель тестов. Номера соответствуют ID в базе
    /// </summary>
    public enum EnumPTests
    {
        /// <summary>
        /// Несуществующий тест
        /// </summary>
        NotTest=0,
        /// <summary>
        /// Тест Кеттелла С
        /// </summary>
        KettellC = 1,
        /// <summary>
        /// Тест ПНН
        /// </summary>
        PNN = 2,
        /// <summary>
        /// Тест Адаптивность
        /// </summary>
        Adaptability = 3,
        /// <summary>
        /// Тест FPI
        /// </summary>
        FPI = 4,
        /// <summary>
        /// Тест Кеттелла А
        /// </summary>
        KettellA = 5,
        /// <summary>
        /// Тест Модуль2
        /// </summary>
        Modul2 = 6,
         /// <summary>
        /// Контрасты
        /// </summary>
        Contrasts = 8,
        /// <summary>
        /// Прогноз
        /// </summary>
        Prognoz= 9,
         /// <summary>
        /// Аддиктивное поведение
        /// </summary>
       Addictive = 10,
         /// <summary>
        /// Леонгард
        /// </summary>
       Leongard = 11,
         /// <summary>
        /// НПН-А
        /// </summary>
       NPNA = 12
    }
}
