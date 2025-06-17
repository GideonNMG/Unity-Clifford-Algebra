using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public class CliffordOperations
    {

        public static CAComponent BladeProduct(Blade left, Blade right, Metric metric)
        {
            int n = metric.matrix.GetLength(0);

            float[] basis = new float[n + 1];

            basis[0] = 1;

            float scalar = 1f;

            float parity = (float)BladeUtilities.BladeParity(left) * (float)BladeUtilities.ReverseBladeParity(right);

            float productParity = (float)BladeUtilities.BladeProductParity(left, right);

            scalar *= left.basis[0] * BladeUtilities.ReversionFactor(right.basis) * right.basis[0];

            scalar *= parity;

            scalar *= productParity;

            for (int i = 1; i<= n+1; i++)
            {

                if(left.basis[i]!=0 && right.basis[i] != 0)
                {
                    scalar *= left.basis[i] * right.basis[i] * metric.matrix[i - 1, i - 1];

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


            Blade product = new Blade(basis);

            CAComponent result = new CAComponent(product, scalar);

            return result;

        }



        public static CAComponent ComponentProduct(CAComponent left, CAComponent right, Metric metric)
        {
            float scalar = left.scalar * right.scalar;

            CAComponent product = BladeProduct(left.blade, right.blade, metric);

            scalar *= product.scalar;
           
            CAComponent result = new CAComponent(product.blade, scalar);

            return result;
        }
    }

}

