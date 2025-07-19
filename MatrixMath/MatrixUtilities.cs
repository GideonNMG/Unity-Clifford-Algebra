using UnityEngine;
using System;
//using System.Numerics;

namespace MatrixMath
{

    public static class MatrixUtilities
    {

        
        public static float[,] ArrayToMatrix(float[] array, bool column)  //turns a 1d array into a "2d" (1xd) matrix. If the bool is false, it will be a row; if true, a column.
        {
       
            if (column)
            {

                return ArrayToColumn(array);
            }
            else
            {
                return ArrayToRow(array);

            }

        }
        


        public static float[,] ArrayToRow(float[] array)
        {
            int n = array.Length;

            float[,] result = new float[1, n];


            for (int j = 0; j < n; j++)
            {

                result[0, j] = array[j];

            }


            return result;


        }


        public static float[,] ArrayToColumn(float[] array)
        {
            int n = array.Length;

            float[,] result = new float[n, 1];


            for (int i = 0; i < n; i++)
            {

                result[i, 0] = array[i];

            }

            return result; 
           

        }


        public static float[] Vector2ToArray(UnityEngine.Vector2 vect)
        {

            float[] result = new float[2];

            result[0] = vect.x;

            result[1] = vect.y;

            return result;

        }


        public static float[,] Vector2ToRow(UnityEngine.Vector2 vect)
        {
            float[] array = new float[2];

            array = Vector2ToArray(vect);

            return ArrayToRow(array);

        }

        public static float[,] Vector2ToColumn(UnityEngine.Vector2 vect)
        {
            float[] array = new float[2];

            array = Vector2ToArray(vect);

            return ArrayToColumn(array);

        }



        public static float[] Vector3ToRightHandedArray(UnityEngine.Vector3 vect)
        {

            float[] result = new float[3];

            result[0] = vect.x;

            result[1] = vect.z;

            result[2] = vect.y;

            return result;
        }

        
        public static float[,] Vector3ToRightHandedColumn(UnityEngine.Vector3 vect)
        {

            float[] array = new float[3];

            array = Vector3ToRightHandedArray(vect);


            return ArrayToColumn(array);
        }

        public static float[,] Vector3ToRightHandedRow(UnityEngine.Vector3 vect)
        {

            float[] array = new float[3];

            array = Vector3ToRightHandedArray(vect);


            return ArrayToRow(array);
        }

        public static float[] Vector4ToArray(UnityEngine.Vector4 vect)
        {

            float[] result = new float[4];

            result[0] = vect.x;

            result[1] = vect.y;

            result[2] = vect.z;

            result[3] = vect.w;

            return result;
        }


        public static float[,] Vector4ToRow(UnityEngine.Vector4 vect)
        {
            float[] array = new float[4];

            array = Vector4ToArray(vect);

            return ArrayToRow(array);

        }


        public static float[,] Vector4ToColumn(UnityEngine.Vector4 vect)
        {
            float[] array = new float[4];

            array = Vector4ToArray(vect);

            return ArrayToColumn(array);

        }


        public static float[,] SetAllOne(int n)
        {

            float[,] A = new float[n, n];

            for(int i = 0; i < n; i++)
            {

                for(int j = 0; j < n; j++)
                {

                    A[i, j] = 1;
                }

            }

            return A;
        }


        public static float[,] SetAllZero(int n)
        {

            float[,] A = new float[n, n];

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {

                    A[i, j] = 0;
                }

            }

            return A;
        }


        public static float[,] DiagonalOnes(int n)
        {

            float[,] A = SetAllZero(n);

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        A[i, j] = 1;

                    }

                    
                }

            }

            return A;
        }


    }


}
