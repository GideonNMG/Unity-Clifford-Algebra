using UnityEngine;
using System.Collections;


namespace MatrixMath
{
    public static class ConstantMatrices
    {
       

        public static float[,] Id2()
        {

            return StaticMatrices.Id(2);
        }


        public static float[,] Id3()
        {

            return StaticMatrices.Id(3);
        }


        public static float[,] Id4()
        {

            return StaticMatrices.Id(4);
        }


        public static float[,] Fibonacci()
        {
            float[,] A = MatrixUtilities.SetAllOne(2);

            A[1, 1] = 0;

            return A;
        }

    }


}


