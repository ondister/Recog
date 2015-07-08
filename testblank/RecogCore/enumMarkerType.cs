using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.RecogCore
{
    public enum MarkerType
    {
        /// <summary>
        /// Верхний правый маркер
        /// </summary>
        TopRight=1,
        /// <summary>
        /// Верхний левый маркер
        /// </summary>
        TopLeft=2,
        /// <summary>
        ///Верхний центральный маркер для определения ориентации бланка
        /// </summary>
        TopCenter=3,
        /// <summary>
        /// Нижний правый маркер
        /// </summary>
        BottomRight=4,
        /// <summary>
        /// Нижний левый маркер
        /// </summary>
        BottomLeft=5,
        /// <summary>
        /// Неизвестный тип маркера
        /// </summary>
        UnKnown=0
    };
}
