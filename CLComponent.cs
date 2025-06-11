using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public struct CLComponent
    {
        public Blade blade;

        public float scalar;


        public CLComponent(Blade blade, float c)
        {
            this.scalar = c;

            this.blade = blade;
        }


    }


}
