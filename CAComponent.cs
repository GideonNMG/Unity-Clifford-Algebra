using UnityEngine;


namespace Clifford.Algebra
{
    public struct CAComponent
    {
        public Blade blade;

        public float scalar;


        public CAComponent(Blade blade, float c)
        {
            this.scalar = c;

            this.blade = blade;
        }

    }


}

