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



    }


}

