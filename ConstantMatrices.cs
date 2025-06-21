using UnityEngine;
using System.Collections;


namespace MatrixMath
{
    public static class ConstantMatrices
    {
        public static float[,] Fibonacci()
        {
            float[,] A = MatrixUtilities.SetAllOne(2);

            A[1, 1] = 0;

            return A;
        }


        public static float[,] Rotation2D(float theta)
        {

            float[,] R = new float[2, 2];

            R[0, 0] = R[1, 1] = Mathf.Cos(theta);

            R[0, 1] = -Mathf.Sin(theta);

            R[1, 0] = -R[0, 1];

            return R;
        }

        public static float[,] Yaw(float alpha)
        {
            float[,] Y = MatrixUtilities.DiagonalOnes(3);

            Y[0, 0] = Y[1, 1] = Mathf.Cos(alpha);

            Y[0, 1] = -Mathf.Sin(alpha);

            Y[1, 0] = -Y[0, 1];

            return Y;

        }

        public static float[,] Pitch(float beta)
        {
            float[,] P = MatrixUtilities.DiagonalOnes(3);

            P[0, 0] = P[2, 2] = Mathf.Cos(beta);

            P[0, 2] = Mathf.Sin(beta);

            P[2, 0] = -P[0, 2];

            return P;

        }


        public static float[,] Roll(float gamma)
        {
            float[,] R = MatrixUtilities.DiagonalOnes(3);

            R[1, 1] = R[2, 2] = Mathf.Cos(gamma);

            R[1, 2] = -Mathf.Sin(gamma);

            R[2, 1] = -R[1, 2];

            return R;

        }

        public static float [,] Id(int n)
        {

            return MatrixUtilities.DiagonalOnes(n);
        }

        public static float[,] Id2()
        {

            return Id(2);
        }

        public static float[,] Id3()
        {

            return Id(3);
        }


        public static float[,] Minkowski()
        {

            float[,] result = Id(4);

            result[0, 0] = -1f;

            return result;
        }

    }


}


