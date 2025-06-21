using UnityEngine;


namespace Clifford.Algebra
{
    public struct Term
    {

        public Blade blade;

        public float scalar;


        public Term(Blade blade, float c)
        {
            this.scalar = c;

            this.blade = blade;
        }

    }

}
