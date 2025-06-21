using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public class CliffordOperations
    {

        public static Term BladeProduct(Blade left, Blade right, Metric metric)
        {
            int n = metric.matrix.GetLength(0);

            float[] basis = new float[n + 1];

            basis[0] = 1;

            float scalar = 1f;

            float parity = (float)BladeUtilities.BladeParity(left) * (float)BladeUtilities.BladeParity(right);

            float productParity = (float)BladeUtilities.BladeProductParity(left, right);

            scalar *= left.basis[0] * right.basis[0];

            scalar *= parity;

            scalar *= productParity;

            for (int i = 1; i<= n+1; i++)
            {
                float bi = left.basis[i] + right.basis[i];

                if (bi == 2)
                {
                    scalar *=  metric.matrix[i - 1, i - 1];

                }


                else 
                {
                    basis[i] = bi;

                }
              
            }


            Blade product = new Blade(basis);

            Term result = new Term(product, scalar);

            return result;

        }

        public static Term BladeProduct(Blade left, Blade right)  //If no metric is explcicity required, the metric is assumed to be Euclidean. 
        {
            int n = left.basis.Length - 1;

            float[] basis = new float[n + 1];

            basis[0] = 1;

            float scalar = 1f;

            float parity = (float)BladeUtilities.BladeParity(left) * (float)BladeUtilities.BladeParity(right);

            float productParity = (float)BladeUtilities.BladeProductParity(left, right);

            scalar *= left.basis[0] * right.basis[0];

            scalar *= parity;

            scalar *= productParity;

            for (int i = 1; i <= n + 1; i++)
            {
                float bi = left.basis[i] + right.basis[i];


                    basis[i] = bi %2 ;

            }


            Blade product = new Blade(basis);

            Term result = new Term(product, scalar);

            return result;

        }



        public static Term TermProduct(Term left, Term right, Metric metric)
        {
            float scalar = left.scalar * right.scalar;

            Term product = BladeProduct(left.blade, right.blade, metric);

            scalar *= product.scalar;
           
            Term result = new Term(product.blade, scalar);

            return result;
        }


        public static Term TermProduct(Term left, Term right)
        {
            float scalar = left.scalar * right.scalar;

            Term product = BladeProduct(left.blade, right.blade);

            scalar *= product.scalar;

            Term result = new Term(product.blade, scalar);

            return result;
        }

    }

}

