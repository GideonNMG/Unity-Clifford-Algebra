using UnityEngine;


namespace MatrixMath
{

    public class MatrixOperations
    {

        public static float[,] CofactorMatrix(float[,] matrix, int k, int l)
        {

            int n = matrix.GetLength(0);

            if (n > 1)
            {

                float[,] result = new float[n - 1, n - 1];

                for (int i = 0; i < n; i++)
                {

                    if (i < k)
                    {

                        for (int j = 0; j < n; j++)
                        {

                            if (j < l)
                            {

                                result[i, j] = matrix[i, j];
                            }

                            if (j > l)
                            {
                                result[i, j - 1] = matrix[i, j];

                            }

                        }
                    }

                    if (i > k)
                    {

                        for (int j = 0; j < n; j++)
                        {

                            if (j < l)
                            {

                                result[i - 1, j] = matrix[i, j];
                            }

                            if (j > l)
                            {
                                result[i - 1, j - 1] = matrix[i, j];

                            }

                        }
                    }


                }

                return result;

            }

            else
            {

                Debug.LogWarning("Input to Cofactor Matrix is already scalar!");

                float[,] nullResult = new float[0, 0];

                nullResult[0, 0] = 0f;

                return nullResult;
            }

        }


        public static float Cofactor(float[,] matrix, int k, int l)
        {

            return Sign(k, l) * RecursiveDet(CofactorMatrix(matrix, k, l));

        }



        public static float Sign(int i, int j)
        {

            return (Mathf.Abs(i - j) % 2 == 0) ? 1 : -1;
        }


        public static float RecursiveDet(float[,] a)
        {
            int n = a.GetLength(0);

            float result = 0;

            if (n == 1)
            {
                result = a[0, 0];

            }

            else
            {
                for (int j = 0; j < n; j++)
                {

                    result += Sign(0, j) * a[0, j] * RecursiveDet(CofactorMatrix(a, 0, j));
                }

            }

            return result;
        }


        public static float Determinant(float[,] matrix)
        {

            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
            {
                Debug.LogWarning("Matrix is not square.");

            }

            return RecursiveDet(matrix);

        }      

    }

}

