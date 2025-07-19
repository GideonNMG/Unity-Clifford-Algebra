using UnityEngine;
using System.Collections;
using System;
using System.Linq;

namespace MatrixMath
{
    public static class MetricFromType
    {


        public static Metric MetricTensor(int n, int k, Metrics.MetricType metricType)
        {

            float[,] metricMatrix = Metrics.MetricMatrix(n, k, metricType);

            Metric result = new Metric(metricMatrix);

            return result;
        }

        public static Metric MetricTensor(int n, Metrics.MetricType metricType)
        {
            float[,] matrix = Metrics.Metric(n, metricType);

            Metric metric = new Metric(matrix);

            return metric;

        }

        public static Metric MetricTensor(int n, int k)
        {
            float[,] matrix = Metrics.Metric(n, k);

            Metric metric = new Metric(matrix);

            return metric;

        }

        public static Metric MetricTensor(float[] eigenvalues)
        {
            float[,] matrix = Metrics.Metric(eigenvalues);

            Metric metric = new Metric(matrix);

            return metric;

        }

        public static Metric MetricTensor(float[,] metricMatrix)
        {
            Metric metric = new Metric(metricMatrix);

            return metric;

        }

        public static Metric EuclideanMetric(int n)
        {

            float[,] euclidean = Metrics.EuclideanMatrix(n);

            Metric result = new Metric(euclidean);

            return result;
        }

        public static Metric MinkowskiMetric()
        {        

            Metric result = new Metric(StaticMatrices.Minkowski());

            return result;
        }


    }

}
