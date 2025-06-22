using UnityEngine;
using MatrixMath;
using ComplexNumbers;

namespace Clifford.Algebra
{
    public struct Term
    {

        public Blade blade;

        public float scalar;


        public Term(float c, Blade blade)
        {
            this.scalar = c;

            this.blade = blade;
        }


        //Term Operations:
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

            for (int i = 1; i <= n + 1; i++)
            {
                float bi = left.basis[i] + right.basis[i];

                if (bi == 2)
                {
                    scalar *= metric.matrix[i - 1, i - 1];

                }


                else
                {
                    basis[i] = bi;

                }

            }


            Blade product = new Blade(basis);

            Term result = new Term(scalar, product);

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


                basis[i] = bi % 2;

            }


            Blade product = new Blade(basis);

            Term result = new Term(scalar, product);

            return result;

        }


        public static Term TermProduct(Term left, Term right, Metric metric)
        {
            float scalar = left.scalar * right.scalar;

            Term product = BladeProduct(left.blade, right.blade, metric);

            scalar *= product.scalar;

            Term result = new Term(scalar, product.blade);

            return result;
        }


        public static Term TermProduct(Term left, Term right)
        {
            float scalar = left.scalar * right.scalar;

            Term product = BladeProduct(left.blade, right.blade);

            scalar *= product.scalar;

            Term result = new Term(scalar, product.blade);

            return result;
        }


        public static Term HodgeStarDual(Term term)
        {

            float[] basis = term.blade.basis;

            float[] dualBasis = BladeUtilities.Dual(basis);

            int[] hodgeIndecies = BladeUtilities.BladeDualIndices(basis, dualBasis);

            float parity = (float)MathUtilities.CheckPermutation(hodgeIndecies);

            float scalar = term.scalar *= parity;

            Blade dualBlade = new Blade(dualBasis);

            Term result = new Term(scalar, dualBlade);

            return result;
        }

        public static Term SquareProduct(Term term, Metric metric)
        {
            return Term.TermProduct(term, term, metric);

        }

        public static Term SquareProduct(Blade blade, Metric metric)
        {
            return Term.BladeProduct(blade, blade, metric);

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

            Term product = SquareProduct(blade, metric);

            float result = product.scalar;

            result *= BladeUtilities.BladeParity(product.blade);

            return result;


        }

        public static Term Unit(Blade blade, Metric metric)
        {
            Term product = SquareProduct(blade, metric);

            float sv = SquareValue(blade, metric);

            float scalar = 1f;

            if (sv != 0)
            {
                scalar = 1 / sv;

            }

            Term result = new Term(scalar, blade);

            return result;
        }


        public static Term[] ComplexTerm(float re, float im)
        {
            Term[] result = new Term[2];

            result[0] = new Term(re, ConstantAlgebras.PlaneEvenCA().blades[0]);

            result[1] = new Term(im, ConstantAlgebras.PlaneEvenCA().blades[1]);

            return result;
        }

        //Equality Override:
        public override bool Equals(object term)
        {
            if (term == null)
            {
                return false;
            }

            var t = (Term)term;
            return (scalar == t.scalar && Blade.BladeEquality(blade, t.blade));
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


        public static bool TermEquality(Term first, Term second)
        {

            if(first.scalar == second.scalar && Blade.BladeEquality(first.blade, second.blade))
            {

                return true;

            }

            else
            {

                return false;
            }
        }

        public static bool operator ==(Term first, Term second)
        {
            return TermEquality(first, second);

        }

        public static bool operator !=(Term first, Term second)
        {
            return !TermEquality(first, second);

        }


        //Operator Overloads:
        public static Term operator * (Term first, Term second) =>
            TermProduct(first, second);

        public static Term operator *(Term term, float c) =>
           new Term(term.scalar * c, term.blade);

        public static Term operator *(float c, Term term) =>
          new Term(term.scalar * c, term.blade);


        public static Term operator *(Term term, int c) =>
         new Term(term.scalar * (float)c, term.blade);


        public static Term operator *(int c, Term term) =>
         new Term(term.scalar * (float)c, term.blade);


    }

}
