using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{

    public struct Blade
    {

        public int n; //  spaceDimension;

        public int d; // algebra dimesnion; 

        public int index;

        public int grade;

        public float[] basis;


        public Blade(float[] basis)
        {

            this.n = basis.Length - 1;

            this.basis = BladeIndex.Mod2Array(basis);

            this.index = BladeIndex.Index(basis);

            this.grade = BladeIndex.Grade(basis);

            this.d = (int)Mathf.Pow(2, (float)n);
        }

    }


}

