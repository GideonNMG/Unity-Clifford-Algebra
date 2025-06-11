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


        public static float[] Mod2Array(float[] array)
        {
            int n = array.Length;

            float[] result = new float[n];

            for(int i = 0; i < n; i++)
            {

                result[i] = (array[i]) % 2;
            }


            return result;

        }


        public static int Grade(Blade blade)
        {

            return (int)Matrices.Trace(blade.basis) - 1;
        }

        public static int Grade(float[] basis)
        {

            return (int)Matrices.Trace(basis) - 1;
        }


        public static Blade BladeFromIndex(int index, int n)
        {
            float[] basis = new float[n + 1];

            int[] bcs = MathUtilities.BinomialCoefficients(n);


            Blade blade = new Blade(basis);

            basis[0] = 1;

            int m = n;

            int g = 0; //grade



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

            r = Grade(array); // == ones left

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

      


    }
      



}
