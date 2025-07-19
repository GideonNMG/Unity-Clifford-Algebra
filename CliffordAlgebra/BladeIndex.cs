using UnityEngine;
using System;
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
    

        public static float[] GetBasisFromIndex(int index, int n, int g, int i, float[] basis)
        {

            if (ones == grade || n <1)
            {

                return basis;
            }


            else
            {

                n--;
                g--;
                if (index < BC(n, g))
                {

                    basis[i] = 1;
                    ones++;
                    i++;

                    GetBasisFromIndex(index, n, g, i, basis);

                   
                }

                else
                {
                    n--;
                    i++;
                    GetBasisFromIndex(index, n, g, i, basis);
                }

            }
    

            return basis;
        }

        public static float[] BasisFromIndex(int index, int n)
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

            float[] basis = new float[n + 1];

            int[] binomial = StaticFunctions.BinomialCoefficients(n);

            grade = BladeUtilities.GradeFromIndex(index, n);

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

                basis[binomial[n - 1] - (index + 1 - (StaticFunctions.BinomialPartialSum(n, n - 2)))] = 0;

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

            float[] basis = BasisFromIndex(index, n);


            Blade blade = new Blade(basis);

            return blade;

        }


        public static int Index(Blade blade)
        {

            return ArrayIndex(blade.basis);

        }


        public static int Index(float[] basis)
        {

            return ArrayIndex(basis);

        }


        public static int ArrayIndex(float[] array)
        {


            q = array.Length;  // == slots left

            r = BladeUtilities.Grade(array); // == ones left

            Checki(array, l);

            return k +1;

        }


        private static void Checki(float[] b, int i)
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



        private static void ArrayiOne(float[] array)
        {

            q--;

            r--;

            if (BC(q,r) == 1)
            {

                return;

            }

            else
            {

                l++;

                Checki(array, l);
            }

        }


        private static void ArrayiZero(float[] array)
        {

            q--;

            r--;

            k += BC(q, r);

            r++;

            if(BC(q,r) == 1)
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
  
    }

}
