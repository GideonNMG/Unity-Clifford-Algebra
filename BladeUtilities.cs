using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using MatrixMath;

namespace Clifford.Algebra
{
    public static class BladeUtilities
    {



        public static int Grade(Blade blade)
        {

            return (int)Matrices.Trace(blade.basis) - 1;
        }

        public static int Grade(float[] basis)
        {

            return (int)Matrices.Trace(basis) - 1;
        }


        public static int GradeFromIndex(int index, int n)
        {
            //example for n == 3

            //index    binomial[i]   i = grade

            //0           1          0

            //1 2 3       3          1

            //4, 5, 6     3          2

            //7           1          3


            int[] binomial = new int[n + 1];

            binomial = MathUtilities.BinomialCoefficients(n);

            int result = 0;

            int lower = 0;

            int upper = 0;

            for (int i = 0; i < n + 1; i++)
            {
                upper += binomial[i];
                if (index >= lower && index < upper)
                {

                    result = i;
                }
                lower += binomial[i];
            }

            return result;

        }


        public static int[] BladeIndices(float[] b)
        {


            int n = b.Length;

            int grade = Grade(b);


            List<int> indecies = new List<int>();

            for(int i = 1; i < n; i++)
            {

                if (b[i] == 1)
                {

                    indecies.Add(i);
                }
            }


            int[] result = indecies.ToArray();

            return result;
        }



        public static int BladeParity(float[] b)
        {

            return MathUtilities.Parity(BladeIndices(b));

        }


        public static float[] Reversion(float[] b)
        {
            int n = b.Length;

            float[] result = new float[n];

            result[0] = b[0];

            for (int i = 1; i < n; i++)
            {

                result[n - i] = b[i];
            }

            return result;
        }


        public static float ReversionFactor(float[] b)
        {
            int k = b.Length -1;

            int m = k * (k - 1) / 2;

            return Mathf.Pow(-1, m);


        }

        public static Blade ReverseBlade(Blade blade)
        {
            float[] basis = blade.basis;

            int n = basis.Length;

            basis = Reversion(basis);



            basis[0] *= ReversionFactor(basis);

            Blade result = new Blade(basis);

            return result;

        }


        public static float[] Dual(float[] b)
        {
            int n = b.Length;

            float[] result = new float[n];

            result[0] = b[0];

            for (int i = 1; i < n; i++)
            {

                result[i] = (b[i] + 1)%2;
            }

            return result;
        }

      

    }


}
