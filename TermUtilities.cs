using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MatrixMath;

namespace Clifford.Algebra
{
    public static class TermUtilities
    {
        public static Term HodgeStarDual(Term term)
        {

            float[] basis = term.blade.basis;

            float[] dualBasis = BladeUtilities.Dual(basis);

            int[] hodgeIndecies = BladeUtilities.BladeDualIndices(basis, dualBasis);

            float parity = (float)MathUtilities.CheckPermutation(hodgeIndecies);

            float scalar = term.scalar *= parity;

            Blade dualBlade = new Blade(dualBasis);

            Term result = new Term(dualBlade, scalar);

            return result;
        }

        public static Term SquareProduct(Term term, Metric metric)
        {
            return CliffordOperations.TermProduct(term, term, metric);

        }

        public static Term SquareProduct(Blade blade, Metric metric)
        {
            return CliffordOperations.BladeProduct(blade, blade, metric);

        }



        public static float SquareValue(Term term, Metric metric)
        {

            Term product = SquareProduct(term, metric);

            float result = product.scalar;

            result *= BladeUtilities.BladeParity(product.blade);

            return result;


        }


        public static float SquareValue(Blade blade, Metric metric)
        {

            Term product = SquareProduct( blade, metric);

            float result = product.scalar;

            result *= BladeUtilities.BladeParity(product.blade);

            return result;


        }


       
         public static Term Unit(Blade blade, Metric metric)
         {
            Term product = SquareProduct(blade,  metric);

            float sv = SquareValue(blade, metric);

            float scalar = 1f;

            if (sv != 0)
            {
                scalar = 1 / sv;
                
            }

            Term result = new Term(blade, scalar);

            return result;
        }


        public static Term[] ComplexTerm(float re, float im)
        {
            Term[] result = new Term[2];

            result[0] = new Term(ConstantAlgebras.PlaneEvenCA().blades[0], re);

            result[1] = new Term(ConstantAlgebras.PlaneEvenCA().blades[1], im);

            return result;
        }
       

    }

}
