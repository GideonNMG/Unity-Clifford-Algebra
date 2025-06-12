using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public static class BladeIndex
    {

        public static int k = 0;

        public static int l = 1;

        public static int q;

        public static int r;



        /*
        public static float[] BasisFromGradeAndIndex(int grade, int index, int n)
        {


        }
        */

  

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

       

            float[] basis = new float[n + 1];

            basis[0] = 1;

            int[] binomial = MathUtilities.BinomialCoefficients(n);


            int grade = BladeUtilities.GradeFromIndex(index, n);

            basis = ArrayUtilities.SetAllZero(n + 1, 1);


            if (grade == 0)
            {

                return basis;
            }

            else
            {
                index = index + 1 - PS(n, grade - 1);
            }

          
            /*
            example n = 5

            basis   grade 
  
              1        0    100000

              5        1    110000  101000 100100  100010 100001 

              10       2    111000  110100 110010 110001 101100 101010 101001 100110 100101 100011
                            6        7      8     9       10     11     12     13     14      15

                            1        2      3     4       5      6      7      8      9       10 

              10       3    111100  111010  111001  110110  110101  110011  1011100 1011010  1011001 100111
                            1       2       3       4       5       6       7        8         9      10   

              5        4    111110  111101  111011  110111  101111

              1        5    111111
    
             */






            if (grade == 1)
            {
             

                basis[index] = 1;

            }

            if(grade == 2)
            {
            

                if ( index <= DPS(n -1, grade -1, 0))
                {

                    basis[1] = 1;
                    basis[index + 1] = 1;

                }


                if(index > DPS(n -1, grade - 1, 0) && index <= DPS(n -1, grade - 1, 1))
                {
                    basis[1] = 0;
                    basis[2] = 1;
                    basis[index + 2 - (DPS(n-1, grade - 1,0))] = 1;

                }

                if(index > DPS(n-1, grade - 1,1) && index<=  DPS(n-1, grade-1,2))
                {

                    basis[1] = 0;
                    basis[2] = 0;
                    basis[3] = 1;
                    basis[index + 3 - (DPS(n - 1, grade - 1, 1))] = 1;


                }

                if(index> DPS(n - 1, grade - 1, 2) && index < DPS(n - 1, grade - 1, 3))
                {
                    basis[1] = 0;
                    basis[2] = 0;
                    basis[3] = 0;
                    basis[4] = 0;
                    basis[index + 4 - (DPS(n - 1, grade - 1, 2))] = 1;
                }

            }




            if(grade == 3)
            {
               if(index < DPS(n-1, grade - 1, 0))
                {
                    basis[1] = 1;

                  if(index < DPS(n-2, grade - 2, 0))
                    {

                        basis[2] = 1;
                        basis[index + 2] = 1;





                    }


                   
                }

            }


            if(grade == n - 2)
            {


            }


            if(grade == n - 1)
            {
                basis = ArrayUtilities.SetAllOne(n + 1);

                basis[binomial[n-1] - (index +1 - (MathUtilities.BinomialPartialSum(n, n - 2)))] = 0;

            }


            if(grade == n)
            {

                basis = ArrayUtilities.SetAllOne(n + 1);
            }


            /*

            if (grade == 0)
            {
                if(index < BC(n, grade))
                {

                    basis[0] = 1;
                }

            }

            if(grade == 1)
            {

            

                if(index >= BC(n, grade -1) && index < binomial[0] + binomial[1])

                basis[index] = 1;
            }

            */
            /*
            if(grade ==2)
            {

                if(index < binomial[0] + binomial[1] + BC(n-1, grade -1))
                {
                    basis[1] = 1;

                    basis[index + 1 - BC(n, grade - 1)] = 1;

                }

                if(index >= binomial[0] + binomial[1] + BC(n - 1, grade - 1) && index < binomial[0] + binomial[1] + BC(n - 1, grade - 1) + BC(n - 1, grade))
                {

                    basis[2] = 1;

                    basis[index + 1 - (BC(n, 1) + BC(n - 1, grade - 1))] = 1;
                }

            }
            */

            /*
            if (grade == 2)
            {
                if(index < BC(n, grade-1) + BC(n - 1, grade - 1))
                {

                    basis[1] = 1;

                    basis[index + 1 - BC(n, grade - 1)] = 1;
                }

                if(index >= BC(n, grade - 1) + BC(n - 1, grade - 1) && index < BC(n, grade - 1) + BC(n - 1, grade - 1) + BC(n-1, grade))
                {
                    basis[2] = 1;

                    basis[index + 1 - (BC(n, 1) + BC(n - 1, grade - 1))] = 1;

                }

                if(index >= BC(n, grade - 1) + BC(n - 1, grade - 1) + BC(n - 1, grade) && index < BC(n, grade - 1) + BC(n - 1, grade - 1) + BC(n - 1, grade) + BC(n-2,grade) )
                {
                    basis[3] = 1;

                    basis[index + 1 - (BC(n, 1) + BC(n - 1, grade - 1) + BC(n - 1, grade))] = 1;

                }

            }



             */

            /*
            if (grade == 3)
            {
                if(index < binomial[0] + binomial[1] + binomial[3] + BC(n-1, grade -1))
                {
                    basis[1] = 1;

                }

            }

            */
            return basis;

        }



        public static Blade BladeFromIndex(int index, int n)
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

            float[] basis = new float[n + 1];

            int[] bcs = MathUtilities.BinomialCoefficients(n);


            int grade = BladeUtilities.GradeFromIndex(index, n);

            basis[0] = 1;

            int m = n;

            int g = 0; //grade


            if(grade == 0)
            {
                basis[0] = 1;

            }


            if(grade == 1)
            {

                basis[index] = 1;
            }

            if(grade == 2)
            {
                if(index < BC(n,grade-1) + BC(n - 1, grade - 1))
                    {
                    basis[1] = 1;

                    basis[index + 1 - n] = 1;

                    }


                if(index >= BC(n,grade-1) + BC(n - 1, grade - 1) && index < BC(n, grade-1) + BC(n - 1, grade - 1) + BC(n - 1, grade))
                {

                    basis[2] = 1;

                    basis[index + 1 - (BC(n, 1) + BC(n - 1, grade - 1))] = 1;

                }

            }


            //grade 0
            if(index == 0)
            {

               for(int i = 1; i < n+1; i++)
                {

                    basis[i] = 0;
                }
            }


            //Grade 1
            if (index <= bcs[1])
            {
                g++;
                m--;
                for (int i = 1; i < n +1; i++)
                {
                    if(i == index)
                    {

                        basis[i] = 1;
                    }

                    else
                    {

                        basis[i] = 0;
                    }
                  
                }
            }

           
             // Grade 2
            if(index >n && index <= MathUtilities.BinomialCoefficient(n, 2))
            {
                g++;
                m--;
                if (index - BC(n,1) < BC(m, g))
                {


                    basis[1] = 1;

                    basis[index + 1 - n] = 1;


                }

                else if (index >= BC(n,1) + BC(m, g) && index < n + BC(m, g) + BC(m, g +1))
                {


                }

            }

            if (MathUtilities.BinomialCoefficient(n, 2) > n && index <= MathUtilities.BinomialCoefficient(n, 3))
            {
                basis[1] = 1;

                basis[2] = 1;

                //basis[index + 1 - n] = 1;

            }

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
       

           return  MathUtilities.BinomialCoefficient(i, j);

        }

        private static int PS(int n, int m)
        {
            return MathUtilities.BinomialPartialSum(n, m);
        }

        private static int DPS(int n, int m, int j)
        {

            return MathUtilities.DescendingPartialSum(n, m, j);

        }


    }

}
