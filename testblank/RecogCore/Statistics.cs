using System;
using System.Collections.Generic;
using System.Linq;

namespace Recog.RecogCore
{
    /// <summary>
    /// Класс со статистическими функциями
    /// </summary>
    public static class Statistics
    {

        /// <summary>
        /// Вычисляет среднее значение
        /// </summary>
        /// <param name="list">Лист со значениями</param>
        /// <returns></returns>
        public static double Mean(List<double> list)
        {
            if (list.Count != 0)
            {
                return list.Sum() / list.Count;
            }
            else { return 0; }
        }

        /// <summary>
        /// Вычисляет среднее значение
        /// </summary>
        /// <param name="list">Библиотека со значениями</param>
        /// <returns></returns>
        public static double Mean(Dictionary<int, double> list)
        {
            if (list.Count != 0)
            {
                return list.Sum(x => x.Value) / list.Count;
            }
            else { return 0; }
        }

        /// <summary>
        ///Вычисляет дисперсию значений
        /// </summary>
        /// <param name="list">Лист со значениями</param>
        /// <returns></returns>
        public static double Disp(List<double> list)
        {
            if (list.Count != 0)
            {
                double mean = Mean(list);
                double meansum = 0;
                for (int i = 0; i < list.Count; i++)
                { meansum += Math.Pow(list[i] - mean, 2); }
                return Math.Sqrt(meansum / (list.Count - 1));
                // return meansum / (list.Count - 1);
            }
            else { return 0; }
        }

        /// <summary>
        /// Вычисляет дисперсию значений
        /// </summary>
        /// <param name="list">Библиотека со значениями</param>
        /// <returns></returns>
        public static double Disp(Dictionary<int, double> list)
        {
            if (list.Count != 0)
            {
                double mean = Mean(list);
                double meansum = 0;
                for (int i = 0; i < list.Count; i++)
                { meansum += Math.Pow(list[i] - mean, 2); }

                return Math.Sqrt(meansum / (list.Count - 1));
                // return meansum / (list.Count - 1);
            }
            else { return 0; }
        }

        /// <summary>
        /// Вычисляет значение абсолютного отклонения от среднего
        /// </summary>
        /// <param name="list">Библиотека со значеними</param>
        /// <param name="Value">Значение для которого определяем отклонение</param>
        /// <returns></returns>
        public static double DevMean(Dictionary<int, double> list, double Value)
        {
            double _devmean = 0;
            double mean = Mean(list);
            _devmean = Math.Abs(Value - mean);

            return _devmean;
        }

        public static double Covariatio(List<double> listX, List<double> listY)
        {
            double c = double.NaN;
            int cnt = listX.Count;
            double zx = 0;
            double zy = 0;
            double zxy = 0;
            if (listX.Count == listY.Count)
            {
                for (int i = 0; i < cnt; i++)
                {
                    zx += listX[i];
                    zy += listY[i];
                    zxy += (listX[i] * listY[i]);
                }
            }
            c = zxy - ((zx * zy) / cnt);
            return c;
        }
        // Z (XiYi) — ((Z Xi)(Z Yi) / N)

        public static double SQ(List<double> listX)
        {
            double c = 0;
            double mean =listX.Average();
            List<double> r = new List<double>();
            for (int i = 0; i < listX.Count; i++)
            {
                r.Add(  Math.Abs(listX[i] - mean));
            }
            c = r.Average();   
            return c;
        }



    }

}
