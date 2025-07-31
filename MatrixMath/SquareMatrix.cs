using UnityEngine;
using System.Collections;


namespace MatrixMath
{
    public struct SquareMatrix
    {
        public float[,] M;

        public int n;

        public SquareMatrix(float[,] A)
        {
            
            this.n = Mathf.Min(A.GetLength(0), A.GetLength(1));

            float[,] M = new float[n, n];

            for(int i = 0; i < n; i++)
            {

                for (int j = 0; i < n; j++)

                   M[i, j] = A[i, j];
            }

            this.M = M;
        }


        public SquareMatrix(Vector2 A, Vector2 B)
        {
            this.n = 2;

            float[,] M = new float[2, 2];

            M[0, 0] = A.x;

            M[1, 0] = A.y;

            M[0, 1] = B.x;

            M[1, 1] = B.y;


            this.M = M;

        }



        public SquareMatrix(Vector2 A, Vector2 B, bool rows)
        {
            this.n = 2;

            float[,] M = new float[2, 2];

            M[0, 0] = A.x;

            M[0, 1] = A.y;

            M[1, 0] = B.x;

            M[1, 1] = B.y;


            this.M = M;

        }



        public SquareMatrix(Vector3 A, Vector3 B, Vector3 C, bool rows)
        {

            if (rows)
            {
                this.n = 3;

                float[,] M = new float[3, 3];

                M[0, 0] = A.x;

                M[0, 1] = A.y;

                M[0, 2] = A.y;

                M[1, 0] = B.x;

                M[1, 1] = B.y;

                M[1, 2] = B.z;

                M[2, 0] = C.x;

                M[2, 1] = C.y;

                M[2, 2] = C.z;


                this.M = M;

            }


            else
            {

                SquareMatrix result = new SquareMatrix(A, B, C);

                this.n = result.n;

                this.M = result.M;
            }


        }



        public SquareMatrix(Vector4 A, Vector4 B, Vector4 C, Vector4 D, bool rows)
        {

            if (rows)
            {
                this.n = 4;

                float[,] M = new float[4, 4];

                M[0, 0] = A.x;

                M[0, 1] = A.y;

                M[0, 2] = A.z;

                M[0, 3] = A.w;

                M[1, 0] = B.x;

                M[1, 1] = B.y;

                M[1, 2] = B.z;

                M[1, 3] = B.w;

                M[2, 0] = C.x;

                M[2, 1] = C.y;

                M[2, 2] = C.z;

                M[2, 3] = C.w;

                M[3, 0] = D.x;

                M[3, 1] = D.y;

                M[3, 2] = D.z;

                M[3, 3] = D.w;


                this.M = M;

            }


            else
            {

                SquareMatrix result =  new SquareMatrix(A, B, C, D);

                this.n = result.n;

                this.M = result.M;
            }
               

        }



        public SquareMatrix(Vector3 A, Vector3 B, Vector3 C)
        {
            this.n = 3;

            float[,] M = new float[3, 3];

            M[0, 0] = A.x;

            M[1, 0] = A.y;

            M[2, 0] = A.z;

            M[0, 1] = B.x;

            M[1, 1] = B.y;

            M[2, 1] = B.z;

            M[0, 2] = C.x;

            M[1, 2] = C.y;

            M[2, 2] = C.z;

            this.M = M;

        }



        public SquareMatrix(Vector4 A, Vector4 B, Vector4 C, Vector4 D)
        {
            this.n = 4;

            float[,] M = new float[4, 4];

            M[0, 0] = A.x;

            M[1, 0] = A.y;

            M[2, 0] = A.z;

            M[3, 0] = A.w;

            M[0, 1] = B.x;

            M[1, 1] = B.y;

            M[2, 1] = B.z;

            M[3, 1] = B.w;

            M[0, 2] = C.x;

            M[1, 2] = C.y;

            M[2, 2] = C.z;

            M[3, 2] = C.w;

            M[0, 3] = D.x;

            M[1, 3] = D.y;

            M[2, 3] = D.z;

            M[3, 3] = D.w;

            this.M = M;

        }


        public SquareMatrix(Vector2 A)
        {
            this.n = 2;

            float[,] M = StaticMatrices.Diagonal(A);


            this.M = M;

        }


        public SquareMatrix(Vector3 A)
        {
            this.n = 2;

            float[,] M = StaticMatrices.Diagonal(A);


            this.M = M;

        }


        public SquareMatrix(Vector4 A)
        {
            this.n = 2;

            float[,] M = StaticMatrices.Diagonal(A);


            this.M = M;

        }


        public static SquareMatrix TransposeMatrix(SquareMatrix A)
        {

            float[,] matrix = A.M;

            float[,] T = Matrices.Transpose(matrix);

            return new SquareMatrix(T);


        }

        public static float Det(SquareMatrix A)
        {

            return Matrices.Det(A);
        }


    }

}
