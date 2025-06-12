using UnityEngine;
using System;


namespace MatrixMath
{

    public static class MathUtilities
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


                for (int i = n; i >= 1; i--)
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

                for (int i = r -s +1; i <= r; i++)
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
          

                for(int i = 0; i < n + 1; i++)
                {
                result[i] = BinomialCoefficient(n, i);

                }

            return result;
           
        }

        public static int BinomialPartialSum(int n, int m)
        {

            int[] binomial = MathUtilities.BinomialCoefficients(n);

            int result = 0;
            for (int i = 0; i < m+1; i++)
            {
                result += binomial[i];

            }

            return result;
        }


        /*   4  1
         * 
         *   3  1
         * 
         *   2  1
         *   
         *   1  1
         */


        public static int[] DescendingBinomial(int n, int k)
        {
            int M = (int)Mathf.Max(n, k);

            int m = (int)Mathf.Min(n, k);

            int[] result = new int[M + 1 -m];



            for (int i = 0; i < M + 1 -m; i++)
            {
              
                result[i] = BinomialCoefficient(M -i, m);
                
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


            return DescendingPartialSum(max, min, max-min);
        }



        public static int PermutationSign(int[] permutation)
        {

            int swaps = 0;

            for (int i = 0; i < permutation.Length; i++)
            {

                if (permutation[i] != i + 1)
                {

                    // Swap the element with the element at its correct position

                    int temp = permutation[i];

                    permutation[i] = permutation[permutation[i] - 1];

                    permutation[permutation[i] - 1] = temp;

                    swaps++;
                }

            }

            return (int)Mathf.Pow(-1f, (swaps % 2));

        }

        public static int PermutationSign(int[] permutation, int[] target)
        {

            int swaps = 0;

            int n = permutation.Length;

            for (int i = 0; i < n; i++)
            {

                if (permutation[i] != target[i])
                {

                    // Swap the element with the element at its correct position

                    int temp = permutation[i];

                    int k = (permutation[i] - 1) % n;

                    permutation[i] = permutation[k];

                    permutation[k] = temp;

                    swaps++;
                }

            }

            return (int)Mathf.Pow(-1f, (swaps % 2));

        }



        public static int PermutationSign(int[] permutation, int start)
        {

            int swaps = 0;

            int L = permutation.Length;

            int[] target = new int[L];

            int val = start;

            for (int k = 0; k < L; k++)
            {
                target[k] = val;

                val++;

            }

            if (target.Length != L)
            {

                Debug.LogWarning("Target array length does not match into array length. Returning 0.");
                return 0;

            }

            int match = 0;

            for (int i = 0; i < L; i++)
            {

                if (permutation[i] != target[i])
                {

                    for (int j = 0; j < L; j++)
                    {
                        if (target[j] == permutation[i])
                        {
                            match = j;
                            break;

                        }

                    }
                    // Swap the element with the element at its correct position

                    int temp = permutation[i];

                    permutation[i] = target[i];

                    permutation[match] = temp;

                    swaps++;

                }

            }

            return (int)Mathf.Pow(-1f, (swaps % 2));

        }


    


        public static int LeviCivita(int[] indices)
        {
            //Get number of indices 
            int n = indices.Length;

            int[] permTarget = new int[n];
            // Check for repeated indices and set permTaget = indices.
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (indices[i] == indices[j])
                    {
                        return 0;
                    }
                }

                //permTarget[i] = indices[i];


            }

            //return CheckCyclic(indices);

           
            // Use Array.Sort to sort the integers in parmTarget from low to high.          

            Array.Sort(permTarget);

            // Use PermutationSign to get the sign of the permutaion of "indices" relative to the sorted "permTarget."

            return PermutationSign(indices, permTarget);      

        }


        public static int Parity(int[] indices)
        {
            //Get number of indices 
            int n = indices.Length;


            // Check for repeated indices and set permTaget = indices.
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (indices[i] == indices[j])
                    {
                        return 0;
                    }
                }


            }

            return CheckCyclic(indices);

        }



        public static int Parity(int[] indices, int start)
        {
            //Get number of indices 
            int n = indices.Length;


            // Check for repeated indices and set permTaget = indices.
            for (int i = start; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (indices[i] == indices[j])
                    {
                        return 0;
                    }
                }


            }

            return CheckCyclic(indices);

        }

   
        public static int CheckCyclic(int[] indices)
        {

            int n = indices.Length;

            int parity = 0;

            for (int i = 0; i < n; i++)
            {

                if (AntiCyclic(indices[i - 1], indices[i]))
                {
                    parity++;

                }
            }

            return (int)Mathf.Pow(-1, (parity) % 2);

        }



        public static bool AntiCyclic(int i, int j)
        {


            bool firstCondition = false;

            bool secondCondition = false;

            //if ((j < i) && (((i - j) % 2) == 1) || j > i && (j - i) % 2 == 0)

            if (j < i && i-j % 2 == 1)
            {
                firstCondition = true;
            }
           

            if (j > i && (j - i) % 2 == 0)
            {
                secondCondition = true;

            }


            if (firstCondition || secondCondition)
            {

                return true;
            }


            else
            {
                return false;
            }

        }
        


        public static int Signature(float[] u, int startIndex)
        {
            int result = 0;

            int l = u.Length;  // l = n+1


            for (int i = startIndex; i < l; i++)
            {

                if (u[i] != 0)
                {

                    for (int j = 1; j < l; j++)
                    {
                        if (u[j] != 0 && AntiCyclic(i, j))
                        {
                            result++;

                        }
                
                    }


                }    


            }

            return result % 2;
        }


        public static int Signature(float[] u) // When no start index is given, it defaults to zero. 
        {
            int result = 0;

            int l = u.Length;  // l = n+1


            for (int i = 0; i < l; i++)
            {

                if (u[i] != 0)
                {

                    for (int j = 1; j < l; j++)
                    {
                        if (u[j] != 0 && AntiCyclic(i, j))
                        {
                            result++;

                        }

                    }


                }


            }

            return result % 2;
        }


        public static int RelativeSignature(float[] u, float[] v, int startIndex)
        {


            int result = 0;

            int l = u.Length;  // l = n+1

            int m = v.Length;

            if (l != m)
            {

                Debug.LogWarning("Signature: Input arrays are not compatible. Returning -1");

                return -1;

            }


            for (int i = startIndex; i < l; i++)
            {

                if (Logic.XorValue(v, u, i))
                {
                    for (int j = startIndex; j < l; j++)
                    {
                        if (v[j] != 0 && AntiCyclic(i, j))
                        {
                            result++;

                        }

                    }

                }


            }

            int sign = (int)Mathf.Pow(-1, result % 2);

            return sign;

        }
           

    }

}


