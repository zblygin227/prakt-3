using System;

namespace Lib_5
{
    public class LibClass
    {

        /// <summary>
        /// Находит среднее ариф. элементов массива 
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        /// <returns>Среднее ариф. число</returns>
        public static float AvgOfNumArr(int[,] arr, out float[] avgArr)
        {
            float avg = 0;
            int col = 0;
            avgArr = new float[arr.GetLength(0)];
            
            for (int i = 0; i < arr.GetLength(0); i+=2)
            {
                avg = 0;
                col = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    avg += arr[i,j];
                    col++;
                }
                avg /= col;
                avgArr[i] = avg;
            }

            return avg;
        }
    }
}
