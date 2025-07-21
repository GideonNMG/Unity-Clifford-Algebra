using UnityEngine;
using System.Collections;


namespace MatrixMath
{
    public static class StaticMatrices
    {

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


        public static float[,] Id(int n)
        {

            return MatrixUtilities.DiagonalOnes(n);
        }


   


        public static float[,] Minkowski()
        {

            float[,] result = Id(4);

            result[0, 0] = -1f;

            return result;
        }


        public static float[,] Diagonal(float[] a)
        {

            int n = a.Length;

            float[,] result = MatrixUtilities.SetAllZero(n);

            for(int i = 0; i < n; i++)
            {

                result[i, i] = a[i];
            }

            return result;

        }


        public static float[,] Reflection3D(Vector3 N)
        {

            float l = Mathf.Sqrt(Vector3.Dot(N, N));

            Vector3 n = new Vector3(N.x / l, N.y / l, N.z / l);

            float[,] result = new float[3, 3];

            result[0, 0] = 1 -2* (n.x * n.x);

            result[0, 1] = - 2 *(n.x * n.y);

            result[0, 2] = - 2 * (n.x * n.z);

            result[1, 0] = -2 * (n.y * n.x);

            result[1, 1] = 1 -2 * (n.y * n.y);

            result[1, 2] = -2 * (n.y * n.z);

            result[2, 0] = -2 * (n.z * n.x);

            result[2, 1] = -2 * (n.z * n.y);

            result[2, 2] = 1 - 2 * (n.z * n.z);


            return result;


        }

        public static float[,] Shear2DX(float s)
        {


            float[,] result =  MatrixUtilities.DiagonalOnes(2);

            result[0, 1] = s;

            return result;

        }

        public static float[,] Shear2DY(float s)
        {


            float[,] result = MatrixUtilities.DiagonalOnes(2);

            result[1, 0] = s;

            return result;

        }


        public static float[,] Shear3DX(float sy, float sz)
        {


            float[,] result = MatrixUtilities.DiagonalOnes(3);

            result[1, 0] = sy;

            result[2, 0] = sz;


            return result;

        }

        public static float[,] Shear3DY(float sx, float sz)
        {


            float[,] result = MatrixUtilities.DiagonalOnes(3);

            result[0, 1] = sx;

            result[2, 1] = sz;


            return result;

        }

        public static float[,] Shear3DZ(float sx, float sy)
        {


            float[,] result = MatrixUtilities.DiagonalOnes(3);

            result[0, 2] = sx;

            result[1, 2] = sy;


            return result;

        }



    }


}
