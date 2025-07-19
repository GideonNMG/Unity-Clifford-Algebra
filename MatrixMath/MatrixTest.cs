using UnityEngine;
using System.Collections.Generic;

namespace Kalend.Algebra
{


    public static class MatrixTest
    {
        public static readonly float[,] A = { { 0, 0, 0, 1 }, { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 } };

        public static readonly float[,] B = { { 0, 1 }, { -1, 0 } };


        public static readonly float[,] C = { { 0, 1, 0 }, { 1, 0, 0 }, { 0, 0, 1 } };


        public static readonly float[,] I = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };


        public static readonly float[,] I_2 = { { 1, 0}, { 0, 1, } };



    }


}
