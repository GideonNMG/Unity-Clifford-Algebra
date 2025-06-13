using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public class CliffordOperations
    {

        public static Blade BladeProduct(Blade left, Blade right, Metric metric)
        {
            int n = metric.matrix.GetLength(0);

            float[] basis = new float[n + 1];

            basis[0] = left.basis[0] * BladeUtilities.ReversionFactor(right.basis) * right.basis[0];

            for (int i = 1; i<= n+1; i++)
            {

                if(left.basis[i]!=0 && right.basis[i] != 0)
                {
                    basis[0] *= left.basis[i] * right.basis[i] * metric.matrix[i - 1, i - 1];

                }


                else if(Logic.XorValue(left.basis[i], right.basis[i], 1f))
                {
                    basis[i] = 1;

                }

                else if(left.basis[i] == 0 && right.basis[i] == 0)
                {

                    basis[i] = 0;
                }
            }


            Blade result = new Blade(basis);

            return result;

        }


        public static CAComponent ComponentProduct(CAComponent left, CAComponent right, Metric metric)
        {
            float c = left.scalar * right.scalar;

            Blade productBlade = BladeProduct(left.blade, right.blade, metric);

            CAComponent result = new CAComponent(productBlade, c);

            return result;
        }
    }


}

