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

            this.blades = BladesFromType(algebraType, n,d);

        }


        public static Blade[] BladesFromType(AlgebraType algebraType, int n, int d)
        {


            Blade[] result = BladeIndex.GetBladesFromIndex(n, d);

            switch (algebraType)
            {
                case AlgebraType.Full:


                    break;

                case AlgebraType.EvenSubalgebra:
                    result = EvenSubalgebra(result);

                    break;

                case AlgebraType.ScalarPseudoscalar:
                    result = ScalarPseudoscalar(result);

                    break;

            }

            return result;

        }


        public static Blade[] EvenSubalgebra(CliffordAlgebra CA)
        {

            int n = CA.n;

            int m = n / 2;

            Blade[] result = new Blade[m];

            int k = 0;

            for (int i = 0; i < n; i++)
            {
                if (BladeUtilities.Grade(CA.blades[i]) % 2 == 0)
                {

                    result[k] = CA.blades[i];

                    k++;
                }

            }


            return result;

        }

        public static Blade[] EvenSubalgebra(Blade[] blades)
        {

            int n = blades.Length;

            int m = n / 2;

            Blade[] result = new Blade[m];

            int k = 0;

            for (int i = 0; i < n; i++)
            {
                if (BladeUtilities.Grade(blades[i]) % 2 == 0)
                {

                    result[k] = blades[i];

                    k++;
                }

            }


            return result;

        }


        public static Blade[] ScalarPseudoscalar(CliffordAlgebra CA)
        {

            int n = CA.n;

            Blade[] result = new Blade[2];

            result[0] = CA.blades[0];

            result[1] = CA.blades[n - 1];

            return result;

        }

        public static Blade[] ScalarPseudoscalar(Blade[] blades)
        {

            int n = blades.Length;

            Blade[] result = new Blade[2];

            result[0] = blades[0];

            result[1] = blades[n - 1];

            return result;

        }


    }

}

