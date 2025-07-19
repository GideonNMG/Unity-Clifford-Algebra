using UnityEngine;
using System.Collections;


namespace MatrixMath
{
    public static class Matrices
    {


        public static float[,] MatrixProduct(float[,] a, float[,] b)
        {

            int n = a.GetLength(0);

            int m = a.GetLength(1);

            int p = b.GetLength(1);


            float[,] result = new float[n, p];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    float[] t = new float[n];

                    for (int k = 0; k < m; k++)
                    {

                        if (k == 0)
                        {

                            t[0] = (a[i, 0] * b[0, j]);

                        }

                        else
                        {

                            t[k] = t[k - 1] + (a[i, k] * b[k, j]);
                        }

                    }

                    result[i, j] = t[m - 1];

                }

            }

            return result;

        }


        public static float[,] SafeMatrixProduct(float[,] a, float[,] b)
        {

            if (Compatible(a, b))
            {

                return MatrixProduct(a, b);
            }

            else
            {

                float[,] result = new float[0, 0];

                result[0, 0] = 0f;

                return result;
            }
        }



        public static float Trace(float[,] matrix)
        {
            int n = matrix.GetLength(0);

            float result = 0;

            for (int i = 0; i < n; i++)
            {

                result += matrix[i, i];
            }

            return result;
        }

        // This is a "cheat" in that we can use a (1D) array to represent a diagonal matrix and this finds the "trace" of such a "matrix."
        public static float Trace(float[] array)
        {
            int n = array.GetLength(0);

            float result = 0;

            for (int i = 0; i < n; i++)
            {

                result += array[i];
            }

            return result;
        }


        public static float Trace(int[] array)
        {
            int n = array.GetLength(0);

            float result = 0;

            for (int i = 0; i < n; i++)
            {

                result += array[i];
            }

            return result;
        }



        public static float[,] Transpose(float[,] a)
        {

            int n = a.GetLength(0);

            int m = a.GetLength(1);


            float[,] result = new float[m, n];

            for(int i = 0; i < n; i++)
            {


                for(int j = 0; j < m; j++)
                {

                    result[j, i] = a[i, j];
                }
            }

            return result;

        }


        //Checks to see if two matrices can be multiplied, i.e., if the first has as many columns as the second has rows. 
        static bool Compatible(float[,] A, float[,] B)
        {

            if (A.GetLength(1) == B.GetLength(0))
            {
                return true;
            }
            else
            {

                return false;
            }
        }
       
      

    }
}