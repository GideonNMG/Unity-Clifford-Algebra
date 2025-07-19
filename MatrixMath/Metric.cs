using UnityEngine;
using System.Collections;
using System;
using System.Linq;

namespace MatrixMath
{
    public struct Metric
    {

        public float[,] matrix;

        public float n;
   
        public Metric(float[,] matrix)
        {

            this.matrix = matrix;

            this.n = matrix.GetLength(0);

        }


    }


}
