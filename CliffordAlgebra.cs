using UnityEngine;
using System;
using MatrixMath;

namespace Clifford.Algebra
{


    public enum AlgebraType
    {

        Full,

        EvenSubalgebra,

        ScalarPseudoscalar,

        Other

    };

    
    public struct CliffordAlgebra
    {
        public Metric metric;

        public int d; //space dimension.

        public int n; //algebra dimension.

        public Blade[] blades;

        public AlgebraType algebraType;


        public CliffordAlgebra(Metric metric, AlgebraType algebraType)
        {

            this.metric = metric;

            this.d = metric.matrix.GetLength(0);

            this.n = (int)Mathf.Pow(2, d);


            this.algebraType = algebraType;

            this.blades = Subalgebras.BladesFromType(algebraType, n,d);

        }

      
    }

}

