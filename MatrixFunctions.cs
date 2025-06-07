using UnityEngine;
using System.Collections;
using System.Linq;

namespace MatrixMath
{
    public class MatrixFunctions 
    {



        public static float[,] MatrixProduct(float[,] a, float[,] b, int n)
        {

            float[,] result = new float[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    float[] t = new float[n];

                    for (int k = 0; k < n; k++)
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


                    result[i, j] = t[n - 1];

                }

            }

            return result;


        }

        static float[,] MatrixProduct(float[,] a, float[,] b, int n, int m, int l)
        {

            float[,] result = new float[n, l];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    float[] t = new float[m];

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




        public static float[,] ShrinkRows(float[,] matrix, int n)
        {

            int m = matrix.GetLength(0);

            int p = matrix.GetLength(1);

            if (m == n)
            {

                Debug.Log("Input mnatrix already has " + n + " rows.");

                return matrix;
            }

            else if (m < n)
            {
                Debug.Log("Input matrix already has fewer rows than number requested.");
                return matrix;
            }

            else
            {
                float[,] result = new float[n, p];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < p; j++)
                    {

                        result[i, j] = matrix[i, j];
                    }

                }

                return result;

            }
        }



        public static float[,] ShrinkColumns(float[,] matrix, int n)
        {

            int m = matrix.GetLength(0);

            int p = matrix.GetLength(1);

            if (p == n)
            {

                Debug.Log("Input mnatrix already has " + n + " columns.");

                return matrix;
            }

            else if (p < n)
            {
                Debug.Log("Input matrix already has fewer columns than number requested.");
                return matrix;
            }

            else
            {
                float[,] result = new float[m, n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {

                        result[i, j] = matrix[i, j];
                    }

                }

                return result;

            }
        }


        static int Compare(float[,] A, float[,] B)
        {

            int n = A.GetLength(1);

            int m = B.GetLength(0);

            if (n == m)
            {

                return 0;

            }

            return Mathf.Min(m, n);

        }


        public static float[,] ForceSquareShrink(float[,] matrix)
        {
            int n = matrix.GetLength(0);

            int m = matrix.GetLength(1);

            if (n == m)
            {

                return matrix;
            }


            else
            {
                int p = Mathf.Min(n, m);

                float[,] result = new float[p, p];

                for (int i = 0; i < p; i++)
                {
                    for (int j = 0; j < p; j++)
                    {

                        result[i, j] = matrix[i, j];
                    }

                }

                return result;

            }
        }




        static bool CheckArray(float[,] A, int n, int m)
        {
            if (A.GetLength(0) == n && A.GetLength(1) == m)
            {
                return true;
            }

            else
            {

                return false;

            }
        }





        public static float SumTest(float[] a)
        {

            return a.Sum();
        }




    }


}
