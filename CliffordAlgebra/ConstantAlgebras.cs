using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{
    public static class ConstantAlgebras
    {
        public static CliffordAlgebra PlaneCA()
        {
            Metric planeMetric = new Metric(ConstantMatrices.Id2());

            CliffordAlgebra planeCA = new CliffordAlgebra(planeMetric, AlgebraType.Full);

            return planeCA;

        }

        public static CliffordAlgebra PlaneEvenCA()
        {
            Metric planeMetric = new Metric(ConstantMatrices.Id2());

            CliffordAlgebra planeCA = new CliffordAlgebra(planeMetric, AlgebraType.EvenSubalgebra);

            return planeCA;

        }

        //public static Term[] PlaneEvenTerms()
        //{

        //    Term[] result = new Term[2];

        //    Term[] 
        //}

    }


}
