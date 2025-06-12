using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{

    public struct Blade
    {

        public int n; //  spaceDimension;

        public int d; // algebra dimension;

        public int index;

        public int grade;

        public float[] basis;


        public Blade(float[] basis)
        {

            this.n = basis.Length - 1;

            this.basis = ArrayUtilities.Mod2Array(basis);

            this.index = BladeIndex.Index(basis);

            this.grade = BladeUtilities.Grade(basis);

            this.d = (int)Mathf.Pow(2, (float)n);
        }

    }


}

