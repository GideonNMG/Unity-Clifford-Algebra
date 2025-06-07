using UnityEngine;
using System.Collections;
using System.Linq;

namespace MatrixMath
{
    public static class Metrics
    {


        public static float[,] EuclideanMetric(int n)
        {
            float[,] result = new float[n, n];

            for (int i = 0; i < n; i++)
            {


                for (int j = 0; j < n; j++)
                {

                    if (i == j)
                    {
                        result[i, j] = 1f;

                    }

                    else
                    {

                        result[i, j] = 0f;
                    }
                }

            }

            return result;
        }


        public static float[,] LorentzianMetric(int n, int k, int l) // n = dimesnion; i = number of postive values; j = number of negative values;
        {


            float[,] result = new float[n, n];

            for (int i = 0; i < n; i++)
            {


                for (int j = 0; j < n; j++)
                {

                    if (i == j)
                    {
                        if (i < k)
                        {
                            result[i, j] = 1f;
                        }

                        else
                        {
                            result[i, j] = -1f;

                        }

                    }

                    else
                    {

                        result[i, j] = 0f;
                    }
                }

            }


            return result;
        }



        public static float[,] LorentzianMetric(int n, int k, int l, bool negativeFirst) // n = dimesnion; i = number of postive values; j = number of negative values; 
        {


            float[,] result = new float[n, n];

            for (int i = 0; i < n; i++)
            {


                for (int j = 0; j < n; j++)
                {

                    if (i == j)
                    {
                        if (i < k)
                        {
                            result[i, j] = -1f;
                        }

                        else
                        {
                            result[i, j] = 1f;

                        }

                    }

                    else
                    {

                        result[i, j] = 0f;
                    }
                }

            }

            return result;
        }

        public static float[,] DiagonalMetric(float[] eigenValues)
        {
            int n = eigenValues.Length;

            float[,] result =  new float[n, n];


            for (int i = 0; i < n; i++)
            {


                for (int j = 0; j < n; j++)
                {

                    if (i == j)
                    {
                        result[i, j] = eigenValues[i];

                    }

                    else
                    {

                        result[i, j] = 0f;
                    }
                }

            }

            return result;

        }


    }

}






