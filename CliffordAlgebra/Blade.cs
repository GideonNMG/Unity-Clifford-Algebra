using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MatrixMath;
using ComplexNumbers;

namespace Clifford.Algebra
{

    public struct Blade
    {

        public int n; //  spaceDimension;

        public int d; // algebra dimension;

        public int index;

        public int grade;

        public int[] basis;


        public Blade(int[] basis)
        {

            this.n = basis.Length - 1;

            this.basis = ArrayUtilities.Mod2Array(basis);

            this.index = BladeIndex.Index(basis);

            this.grade = Grade(basis);

            this.d = (int)Mathf.Pow(2, (float)n);
        }

 


        //Equality Override:
        public static bool BladeEquality(Blade one, Blade two)
        {
            int n = one.basis.Length;

            int m = two.basis.Length;

            if (n != m)
            {

                return false;
            }

            else
            {

                for (int i = 0; i < n; i++)
                {

                    if (one.basis[i] != two.basis[i])
                        return false;
                }
            }

            return true;

        }
 

        public override bool Equals(object blade)
        {
            if (blade == null)
            {
                return false;
            }

            var b = (Blade)blade;
            return (basis == b.basis);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(Blade first, Blade second)
        {
            return BladeEquality(first, second);

        }

        public static bool operator !=(Blade first, Blade second)
        {
            return !BladeEquality(first, second);

        }


        //Blade Utilities:

        public static int NonnullCount(Blade blade)
        {

            int result = 0;

            for(int i=1;i<= blade.n; i++)
            {

                result += blade.basis[i];
            }

            return result;
        }

        public static int Grade(Blade blade)
        {

            return (int)Matrices.Trace(blade.basis) - 1;
        }

        public static int Grade(int[] basis)
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

            binomial = StaticFunctions.BinomialCoefficients(n);

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



        public static int[] BladeIndices(int[] b)
        {


            int n = b.Length;

            int grade = Grade(b);


            List<int> indecies = new List<int>();

            for (int i = 1; i < n; i++)
            {

                if (b[i] == 1)
                {

                    indecies.Add(i);
                }

            }


            int[] result = indecies.ToArray();

            return result;
        }

        public static int[] BladeIndices(Blade blade)
        {

            int[] b = blade.basis;

            return BladeIndices(b);

        }



        public static int[] BladeProductIndices(Blade left, Blade right)
        {
            int[] leftIndecies = BladeIndices(left);

            int[] rightInecies = BladeIndices(right);

            int[] result = leftIndecies.Concat(rightInecies).ToArray();

            return result;

        }


        public static int[] BladeDualIndices(int[] left, int[] right)
        {
            int[] leftIndecies = BladeIndices(left);

            int[] rightInecies = BladeIndices(right);

            int[] result = leftIndecies.Concat(rightInecies).ToArray();

            return result;

        }

        public static int[] BladeDualIndices(Blade left, Blade right)
        {
            int[] leftIndecies = BladeIndices(left);

            int[] rightInecies = BladeIndices(right);

            int[] result = leftIndecies.Concat(rightInecies).ToArray();

            return result;

        }



        public static int BladeParity(int[] b)
        {

            return MathUtilities.Parity(BladeIndices(b));

        }


        public static int BladeParity(Blade blade)
        {


            int[] b = blade.basis;

            return MathUtilities.Parity(BladeIndices(b));

        }


        public static int ReverseBladeParity(Blade blade)
        {

            int[] b = ReverseBlade(blade).basis;

            return MathUtilities.Parity(BladeIndices(b));

        }



        public static int BladeProductParity(Blade left, Blade right)
        {

            int[] bPI = BladeProductIndices(left, right);

            int n = bPI.Length;

            int k = 0;

            for (int i = 0; i < n - 1; i++)
            {

                for (int j = i + 1; j < n; j++)
                {
                    if (bPI[i] == bPI[j])
                    {
                        if (j == i + 1)
                        {
                            break;
                        }

                        else
                        {
                            bPI[j] = bPI[i + 1];

                            bPI[i + 1] = bPI[i];
                            if (MathUtilities.OddPermutation(i, j))
                            {

                                k++;

                            }

                        }
                    }

                }
            }

            return (int)Mathf.Pow(-1, k);

        }



        public static int[] Reversion(int[] b)
        {
            int n = b.Length;

            int[] result = new int[n];

            result[0] = b[0];

            for (int i = 1; i < n; i++)
            {

                result[n - i] = b[i];
            }

            return result;
        }


        public static int ReversionFactor(int[] b)
        {
            int k = b.Length - 1;

            int m = k * (k - 1) / 2;

            return (int)Mathf.Pow(-1, m);


        }


        public static int ReversionFactor(Blade B)
        {
            int k = B.n;

            int m = k * (k - 1) / 2;

            return (int)Mathf.Pow(-1, m);

        }

        public static Blade ReverseBlade(Blade blade)
        {
            int[] basis = blade.basis;

            int n = basis.Length;

            basis = Reversion(basis);



            basis[0] *= ReversionFactor(basis);

            Blade result = new Blade(basis);

            return result;

        }


        public static int[] Dual(int[] b)
        {
            int n = b.Length;

            int[] result = new int[n];

            result[0] = b[0];

            for (int i = 1; i < n; i++)
            {

                result[i] = (b[i] + 1) % 2;
            }

            return result;
        }



        public static Blade DualBlade(Blade blade)
        {

            Blade result = new Blade(Dual(blade.basis));

            return result;

        }



        public static Blade Contraction(Blade one, Blade two)//unsigned contraction (sign will be acounted for in the formula for a product). 
        {
            int N = Mathf.Max(one.n, two.n);

            int M = Mathf.Min(one.n, two.n);

            int[] cbasis = new int[N];

            cbasis[0] = 1;

            for (int i = 1; i <= M; i++)
            {

                cbasis[i] = (one.basis[i] + two.basis[i]) % 2;
            }

            if (N > M && one.n > two.n)
            {
                for (int i = M + 1; i <= N; i++)
                {

                    cbasis[i] = one.basis[i];
                }

            }

            else if(N > M && two.n > one.n)
            {
                for (int i = M + 1; i <= N; i++)
                {

                    cbasis[i] = two.basis[i];
                }
            }

            Blade result = new Blade(cbasis);

            return result;
        }


    }


}

