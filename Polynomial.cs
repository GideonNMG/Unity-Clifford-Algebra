using UnityEngine;
using System;


namespace ComplexNumbers
{
    public struct Polynomial
    {
        //public ComplexNumber z;

        public ComplexNumber[] c;

        public int n;

        public Polynomial(ComplexNumber[] c)
        {

            //this.z = z;

            this.c = c;

            this.n = c.Length;

        }

        public static Polynomial RealPolynomial(float x, float[] a)
        {

            //ComplexNumber z = ComplexNumber.Complexify(x);

            ComplexNumber[] c = ComplexNumber.ComplexifyArray(a);

            Polynomial result = new Polynomial(c);

            return result;

        }

        public static Polynomial RealPolynomial( float[] a)
        {

     
            ComplexNumber[] c = ComplexNumber.ComplexifyArray(a);

            Polynomial result = new Polynomial( c);

            return result;

        }


        public static Polynomial DiophantinePolynomial(int[] a)
        {
            int n = a.Length;

            ComplexNumber[] c = new ComplexNumber[n];
            for(int i = 0; i < n; i++)
            {

                c[i] = ComplexNumber.Complexify((float)a[i]);
            }

            Polynomial result = new Polynomial( c);

            return result;

        }


        //public static ComplexNumber Poly(ComplexNumber z,)
        //{


        //}

    }


}
