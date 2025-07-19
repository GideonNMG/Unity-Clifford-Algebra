using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public static class ArrayUtilities
    {

        public static float[] Mod2Array(float[] array)
        {
            int n = array.Length;

            float[] result = new float[n];

            for (int i = 0; i < n; i++)
            {

                result[i] = (array[i]) % 2;
            }


            return result;

        }

        public static float[] SetAllOne(int n)
        {
            float[] result = new float[n];

            for (int i = 0; i < n; i++)
            {

                result[i] = 1;
            }

            return result;
        }

        public static float[] SetAllOne(int n, int k)
        {
            float[] result = new float[n];

            for (int i = 0; i < n; i++)
            {
                if (i < k)
                {
                    result[i] = 0;

                }

                else
                {
                    result[i] = 1;

                }


            }

            return result;
        }

        public static float[] SetAllZero(int n)
        {
            float[] result = new float[n];

            for (int i = 0; i < n; i++)
            {

                result[i] = 0;
            }

            return result;
        }


        public static float[] SetAllZero(int n, int k)
        {
            float[] result = new float[n];

            for (int i = 0; i < n; i++)
            {
                if (i < k)
                {
                    result[i] = 1;

                }

                else
                {
                    result[i] = 0;

                }


            }

            return result;
        }


        

    }


}
