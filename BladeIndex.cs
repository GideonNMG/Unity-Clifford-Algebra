using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public static class BladeIndex
    {

        public static int k = 0;

        public static int i = 1;

        public static int q;

        public static int r;


        public static int ArrayIndex(float[] array)
        {


            q = array.Length;  // == slots left

            r = (int)Matrices.Trace(array) - 1; // == ones left

            Checki(array, i);

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

            if (BC() == 1)
            {

                return;

            }

            else
            {

                i++;

                Checki(array, i);
            }

        }


        private static void ArrayiZero(float[] array)
        {

            q--;

            r--;

            k += BC();

            r++;

            if(MathUtilities.BinomialCoefficient(q,r) == 1)
            {
                return;

            }

            else
            {

                i++;

                Checki(array, i);
            }
            
        }



        private static int BC()
        {
       

           return  MathUtilities.BinomialCoefficient(q, r);

        }


    }
      



}
