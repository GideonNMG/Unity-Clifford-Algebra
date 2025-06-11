using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using MatrixMath;

namespace Clifford.Algebra
{
    public static class BladeUtilities
    {
      
        public static int[] BladeIndices(float[] b)
        {


            int n = b.Length;

            int grade = BladeIndex.Grade(b);


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
