using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public struct Element
    {

        public CliffordAlgebra cliffordAlgebra;

        public float[] scalars;

        public Term[] terms;

        public Element(CliffordAlgebra cliffordAlgebra, float[] scalars)
        {

            this.cliffordAlgebra = cliffordAlgebra;

            this.scalars = scalars;

            this.terms = ElementTerms(cliffordAlgebra, scalars);

        }


        public static Term[] ElementTerms(CliffordAlgebra cliffordAlgebra, float[] scalars)
        {
            Blade[] blades = cliffordAlgebra.blades;

            int n = blades.Length;

            Term[] result = new Term[n];

            for(int i = 0; i < n; i++)
            {

                result[i] = new Term(scalars[i], blades[i]);


            }

            return result;

        }




    }


}

