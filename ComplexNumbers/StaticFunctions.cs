using UnityEngine;

namespace ComplexNumbers
{
    public static class StaticFunctions
    {
        public static int Factorial(int n)
        {
            if (n < 0)
            {

                Debug.LogWarning("Input to Factorial is negative. Returning -1.");

                return -1;
            }

            else if (n == 0)
            {

                return 1;
            }

            else
            {

                int result = 1;


                for (int i = n; i > 1; i--)
                {

                    result *= i;
                }


                return result;
            }

        }


        public static int BinomialCoefficient(int n, int m)
        {
            int r = Mathf.Max(n, m);

            int s = Mathf.Min(n, m);


            if (s < 0)
            {
                Debug.LogWarning("Input to Binomial Coefficient is negative. Returning -1.");

                return -1;
            }


            else if (s == 0)
            {

                return 1;
            }


            else
            {

                int top = 1;

                for (int i = r - s + 1; i <= r; i++)
                {

                    top *= i;
                }

                float result = top / Factorial(s);

                return (int)result;

            }

        }


        public static int[] BinomialCoefficients(int n)
        {

            int[] result = new int[n + 1];


            for (int i = 0; i < n + 1; i++)
            {
                result[i] = BinomialCoefficient(n, i);

            }

            return result;

        }

        public static int BinomialPartialSum(int n, int m)
        {

            int[] binomial = BinomialCoefficients(n);

            int result = 0;
            for (int i = 0; i < m + 1; i++)
            {
                result += binomial[i];

            }

            return result;
        }



        public static int[] DescendingBinomial(int n, int k)
        {
            int M = (int)Mathf.Max(n, k);

            int m = (int)Mathf.Min(n, k);

            int[] result = new int[M + 1 - m];



            for (int i = 0; i < M + 1 - m; i++)
            {

                result[i] = BinomialCoefficient(M - i, m);

            }

            return result;

        }


        public static int DescendingPartialSum(int n, int m, int k)
        {
            int result = 0;
            int[] db = DescendingBinomial(n, m);

            for (int i = 0; i < k + 1; i++)
            {
                result += db[i];

            }

            return result;
        }

        public static int DescendingSum(int n, int m)  // == BinomialCoefficient(n+1, m+1)
        {

            int max = (int)Mathf.Max(n, m);

            int min = (int)Mathf.Min(n, m);


            return DescendingPartialSum(max, min, max - min);
        }


        public static float DegreesFromRads(float r)
        {

            float result = r * 360f / (2 * Mathf.PI);

            return result;
        }

        public static float Sum(float[] array)
        {
            int n = array.Length;

            float result = 0;

            for(int i = 0; i < n; i++)
            {

                result += array[i];
            }


            return result;

        }


        public static float[] ArraySum(float[,] array)
        {
            int m = array.GetLength(0);

            int n = array.GetLength(1);

            float[] result = new float[m];

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    result[j] += array[j,i];

                }
                
            }

            return result;

        }


        public static float Product(float[] array)
        {
            int n = array.Length;

            float result = 1;

            for (int i = 0; i < n; i++)
            {

                result *= array[i];
            }


            return result;

        }


        public static float AAverage(float[] array)
        {

            int n = array.Length;

            float sum = Sum(array);

            if (n == 0)
            {

                return 0;
            }


            else return sum / n;
            
        }


        public static float GAverage(float[] array)
        {

            int n = array.Length;

            float p = Product(array);

            if (n == 0)
            {

                return 1;
            }


            else
            {

                float result = Mathf.Pow(p, 1 / n);

                return result;
            }

        }



    }

}
