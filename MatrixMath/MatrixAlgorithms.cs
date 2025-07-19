using UnityEngine;


namespace MatrixMath
{

    public static class MatrixAlgorithms
    {

        public static float[,] Inverse(float[,] a)
        {
            int n = a.GetLength(0);

            int m = a.GetLength(1);

            if (n != m)
            {

                Debug.LogWarning("Input matrix is not ssquare. Returning input matrix.");

                return a;
            }


            else
            {
                float det = MatrixOperations.Determinant(a);


                if (det == 0)
                {
                    Debug.LogWarning("Ipout matrix is not invertible!. Retunring input matrix.");
                    return a;

                }

                else
                {

                    float[,] result = new float[n, n];

                    for(int i = 0; i < n; i++)
                    {

                        for(int j = 0; j < n; j++)
                        {

                            result[i, j] = MatrixOperations.Cofactor(a, i, j)/det;
                        }

                    }

                    return Matrices.Transpose(result);

                }

            }
          
        }


        public static float[,]  MatrixScalarMult(float[,] matrix, float x)
        {

            int n = matrix.GetLength(0);

            int m = matrix.GetLength(1);



            float[,] result = new float[n, m];

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {

                    result[i, j] = matrix[i, j] * x;
                }

            }

            return result;
        }


        public static float[,] ReplaceColumn(float[,] a, float[] v, int k)
        {
            int n = a.GetLength(0);

            int m = a.GetLength(1);

            int p = v.Length;

            if (n != p)
            {

                Debug.LogWarning("Column vector does not match input matrix in Replace Column function!");

                    return a;
            }

            else
            {

                float[,] result = new float[n, m];

                for (int i = 0; i < n; i++)
                {

                    for (int j = 0; j < m; j++)
                    {

                        if (j == k)
                        {

                            result[i, j] = v[i];
                        }

                        else
                        {
                            result[i, j] = a[i, j];

                        }
                    }

                }

                return result;

            }

        }

       

        public static float[] Cramer(float[,] A, float[] b)
        {
            int n = A.GetLength(0);

            int m = A.GetLength(1);

            int p = b.Length;

            if(n!=m || m != p)
            {

                Debug.LogWarning("Matrix and vector input to Cramer are not compatible!");

                return b;
            }

            float det = MatrixOperations.Determinant(A);

            if(det == 0)
            {
                Debug.LogWarning("Matrix input to Cramer is not invertable!");

                return b;
            }

            float[] result = new float[n];

            for(int i = 0; i < n; i++)
            {

                result[i] = MatrixOperations.Determinant(ReplaceColumn(A, b, i))/det;
            }

            return result;

        }


    }


}
