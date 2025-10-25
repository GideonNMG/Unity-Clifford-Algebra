using UnityEngine;
using System;
using System.Linq;
using MatrixMath;
using ComplexNumbers;

namespace Clifford.Algebra
{
    public static class BladeIndex
    {

        public static int grade;
        private static int ones;
        public static int k = 0;

        private static int l = 1;

        private static int q;

        private static int r;     
    


        public static int[] GradeZeroBasis(int n)
        {
            int[] result = ArrayUtilities.SetAllZero(n + 1, 1);

            return result;

        }

        public static int[] GradeOneoBasis(int index, int n)
        {
            int[] result = ArrayUtilities.SetAllZero(n + 1, 1);

            result[index] = 1;

            return result;

        }

        public static int[] GradeNBasis(int n)
        {
            int[] result = ArrayUtilities.SetAllOne(n +1);

            return result;

        }


        public static int[] GetBasisFromIndex(int index, int n, int g, int i, int[] basis)
        {


            if (ones == grade||n==0||g==0)

            {

                return basis;
            }

         

            
            else
            {

                    

                if (index <=SafeBC(n-1, g-1) )
                {

                    basis[i] = 1;
                    ones++;
                    i++;
                    n--;
                    index--;

                    GetBasisFromIndex(index, n, g, i, basis);

                   
                }

                else
                {
                    i++;
                    n--;
                    index--;
                  
                    GetBasisFromIndex(index, n, g, i, basis);
                }

            }
    

            return basis;
        }

        public static int[] BasisFromIndex(int index, int n) // n = space dimension; algebra dimension =  2^{n};  0 <= index < 2^{n} 
        {

            /*
            example n = 4

            basis   grade 

            1       0    10000

            4       1    11000  10100 10010  10001 

            6       2    11100  11010 11001 10110 10101 10011
                          12     1 3   1  4   23    2  4   34

            4       3    11110  11101 11011 10111

            1       4    11111


            */



  

            ones = 0;

            int[] basis = new int[n + 1];

            int[] binomial = StaticFunctions.BinomialCoefficients(n);

            grade = Blade.GradeFromIndex(index, n);

            basis = ArrayUtilities.SetAllZero(n + 1, 1);

            basis[0] = 1;

            //int bindex = index;

            if (grade == 0)
            {

                return basis;
            }

            else if (grade == n - 1)
            {
                basis = ArrayUtilities.SetAllOne(n + 1);

                int m = (int)Mathf.Pow(2, n) - 1 - index;

                basis[m] = 0;

                return basis;
            }


            else if (grade == n)
            {

                basis = ArrayUtilities.SetAllOne(n + 1);
                return basis;
            }

            else
            {
                index = index + 1 - PS(n, grade - 1);

                return GetBasisFromIndex(index, n, grade, 1, basis);
            }

        }


        /*
        example n = 5

        basis   grade 

          1        0    100000

          5        1    110000  101000 100100  100010 100001 

          10       2    111000  110100 110010 110001 101100 101010 101001 100110 100101 100011
                        6        7      8     9       10     11     12     13     14      15

                        1        2      3     4       5      6      7      8      9       10 

          10       3    111100  111010  111001  110110  110101  110011  101110 101101  101011   100111
                        1       2       3       4       5       6       7        8         9      10   

          5        4    111110  111101  111011  110111  101111

          1        5    111111

         */


        public static Blade[] GetBladesFromIndex(int n, int d)
        {
            Blade[] result = new Blade[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = BladeFromIndex(i, d);

            }

            return result;

        }

        public static Blade BladeFromIndex(int index, int n)
        {

            int[] basis = BasisFromIndex(index, n);


            Blade blade = new Blade(basis);

            return blade;

        }


        public static int Index(Blade blade)
        {

            return ArrayIndex(blade.basis);

        }


        public static int Index(int[] basis)
        {

            return ArrayIndex(basis);

        }


        public static int ArrayIndex(int[] array)
        {


            q = array.Length;  // == slots left

            r = Blade.Grade(array); // == ones left

            Checki(array, l);

            return k +1;

        }


        private static void Checki(int[] b, int i)
        {


            if (b[i] == 1)
            {

                ArrayiOne(b);

            }

            else
            {

                ArrayiZero(b);

            }

        }



        private static void ArrayiOne(int[] array)
        {

            q--;

            r--;

            if (BC(q,r) == 1|| q==0||r==0)
            {

                return;

            }

            else
            {

                l++;

                Checki(array, l);
            }

        }


        private static void ArrayiZero(int[] array)
        {

            q--;

            r--;


            k += BC(q, r);

            r++;

            if (BC(q, r) == 1 || q == 0 || r == 0)
            {
                return;

            }

            else
            {

                l++;

                Checki(array, l);
            }
            
        }

     
        private static int BC(int i, int j)
        {
       

           return  StaticFunctions.BinomialCoefficient(i, j);

        }

        private static int PS(int n, int m)
        {
            return StaticFunctions.BinomialPartialSum(n, m);
        }

        private static int DPS(int n, int m, int j)
        {

            return StaticFunctions.DescendingPartialSum(n, m, j);

        }

        private static int SafeBC(int n, int g)
        {


            int result = StaticFunctions.SafeBinomialCoefficient(n, g);


            return result;
        }


        public static string[] BasisStrings(int n)
        {
            int N = (int)Mathf.Pow(2, n);

            string[] result = new string[N];

            for(int i = 0; i < N; i++)
            {
                result[i] = BasisString(BasisFromIndex(i, n));

            }

            return result;
        }

        public static int IndexFromBasis(int[] basis)
        {
            int n = basis.Length - 1;

            int k =  Array.IndexOf(BasisStrings(n), BasisString(basis));

            return k;

        }

        public static int IndexFromBasis(string basisString)
        {
            int n = basisString.Length - 1;

            int k = Array.IndexOf(BasisStrings(n), basisString);

            return k;

        }



        public static string BasisString(int[] basis)
        {

            string result = string.Concat(basis.Select(x => x.ToString()));

            //Debug.Log(result);

            return result;
        }


        public static int[] BasisFromString(string s)
        {

            int[] result = s.Split().Select(int.Parse).ToArray();

            //Debug.Log(s);
            //Debug.Log(BasisString(result));

            return result;

        }

    }

}
