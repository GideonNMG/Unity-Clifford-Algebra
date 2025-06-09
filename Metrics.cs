using UnityEngine;
using System.Collections;
using System.Linq;

namespace MatrixMath
{
    public static class Metrics
    {

        public enum MetricType
        {

            Euclidean,

            Minkowski,

            MinkowskiNegativeFirst,

            Lorentzian,

            LorentzianNegativeFirst,

            GeneralizedLorentzian,

            GeneralizedLorentzianNegativeFirst,

            Diagonal,

            Other

        };


       // n = dimension; k = number of negative eigenvalues (only for Generalized Lorentzian); metricType = kind of metric.  
       public static float[,] Metric(int n,int k, MetricType  metricType )
        {

            switch (metricType)
            {

                case  MetricType.Euclidean:


                    return EuclideanMetric(n);

                    //break; // I know that "break" is unreachable, but switch statements don't look right without it. 

                case MetricType.Minkowski:

                    return LorentzianMetric(4);

                    //break;



                case MetricType.MinkowskiNegativeFirst:

                    return LorentzianMetric(4, true);

                    //break;



                case MetricType.Lorentzian:

                    return LorentzianMetric(n);

                    //break;


                case MetricType.LorentzianNegativeFirst:

                    return LorentzianMetric(n, true);

                   // break;



                case MetricType.GeneralizedLorentzian:

                    return LorentzianMetric(n, k);

                    //break;


                case MetricType.GeneralizedLorentzianNegativeFirst:

                    return LorentzianMetric(n, k,  true);

                   // break;



                default:

                    return EuclideanMetric(n);

                    //break;

            }

        }


        public static float[,] Metric(int n, MetricType metricType)
        {

            return Metric(n, 1, metricType);

        }


        public static float[,] Metric(float[] eigenValues)
        {

            return DiagonalMetric( eigenValues);

        }


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



        public static float[,] LorentzianMetric(int n, bool negativeFirst) // n = dimension; a_00 = -1;
        {


            float[,] result = new float[n, n];


            if (negativeFirst)
            {
                for (int i = 0; i < n; i++)
                {


                    for (int j = 0; j < n; j++)
                    {

                        if (i == j)
                        {
                            if (i == 0)
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

            }

            else
            {
                result = LorentzianMetric(n);

            }

            return result;
        }



        public static float[,] LorentzianMetric(int n) // n = dimension; a_00 = -1;
        {


            float[,] result = new float[n, n];

            for (int i = 0; i < n; i++)
            {


                for (int j = 0; j < n; j++)
                {

                    if (i == j)
                    {
                        if (i == n-1 )
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


        public static float[,] LorentzianMetric(int n, int k) // n = dimension; i = number of postive values; j = number of negative values;
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



        public static float[,] LorentzianMetric(int n, int k, bool negativeFirst) // n = dimesnion; i = number of postive values; j = number of negative values; 
        {

            float[,] result = new float[n, n];

            


            if(negativeFirst)
            {
                

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


            }

            else
            {

                result = LorentzianMetric(n, k);
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


        public static float MetricProduct(float[] left, float[] right, MetricType metricType)
        {
            int n = left.Length;

            int m = right.Length;


            if (n != m)
            {

                Debug.LogWarning("Row and column vectors are incombatible");

                return 0f;

            }


            else
            {
                float[,] metric = new float[n, n];

                metric = Metric(n, metricType);

                float[,] rowVector = new float[1, n];

                rowVector = MatrixUtilities.ArrayToRow(left);

                float[,] columnVector = new float[n, 1];

                columnVector = MatrixUtilities.ArrayToColumn(right);

                columnVector = Matrices.MatrixProduct(metric, columnVector);

                float[,] product = new float[1, 1];

                product = Matrices.MatrixProduct(rowVector, columnVector);

                return product[0, 0];

            }

        }


        public static float MetricDistanceSquared(float[] vect, MetricType metricType)
        {

            return MetricProduct(vect, vect, metricType);
        }


    }

}






