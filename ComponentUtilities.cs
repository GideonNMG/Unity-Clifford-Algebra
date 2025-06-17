using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MatrixMath;

namespace Clifford.Algebra
{
    public static class ComponentUtilities
    {
        public static CAComponent HodgeStarDual(CAComponent comp)
        {

            float[] basis = comp.blade.basis;

            float[] dualBasis = BladeUtilities.Dual(basis);

            int[] hodgeIndecies = BladeUtilities.BladeDualIndices(basis, dualBasis);

            float parity = (float)MathUtilities.CheckPermutation(hodgeIndecies);

            float scalar = comp.scalar *= parity;

            Blade dualBlade = new Blade(dualBasis);

            CAComponent result = new CAComponent(dualBlade, scalar);

            return result;
        }

    }

}

