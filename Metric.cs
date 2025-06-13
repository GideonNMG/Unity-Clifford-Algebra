using UnityEngine;
using System.Collections;
using System;
using System.Linq;

namespace MatrixMath
{
    public struct Metric
    {

        //public Metrics.MetricType type;

        public float[,] matrix;

        public float n;

        //public float k;


        public Metric(float[,] matrix)
        {

            //this.type = type;

            this.matrix = matrix;

            this.n = matrix.GetLength(0);

        }


    }


}
