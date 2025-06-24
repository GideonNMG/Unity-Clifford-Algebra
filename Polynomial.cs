using UnityEngine;
using System;


namespace ComplexNumbers
{
    public struct Polynomial
    {
        

        public ComplexNumber[] c;

        public int n;

        public Polynomial(ComplexNumber[] c)
        {

            //this.z = z;

            this.c = c;

            this.n = c.Length-1;

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


        public static ComplexNumber Poly(ComplexNumber z,Polynomial p)
        {


            int n = p.n;

            ComplexNumber P = new ComplexNumber(0, 0);

            for(int i = 0; i < n+1; i++)
            {
                P += p.c[i] * ComplexNumber.Pow(z, n - i);

            }

            return P;

        }


        public static ComplexNumber Poly(float x, Polynomial p)
        {


            int n = p.n;

            ComplexNumber P = new ComplexNumber(0, 0);

            for (int i = 0; i < n + 1; i++)
            {
                P += p.c[i] * Mathf.Pow(x, n - i);

            }

            return P;

        }


        public static float RealPoly(float x, Polynomial p)
        {

            int n = p.n;

            float y = 0f;

            float[] c = ComplexNumber.ReArray(p.c);

            for (int i = 0; i < n + 1; i++)
            {
                y += c[i] * Mathf.Pow(x, n - i);

            }

            return y;

        }


        public static ComplexNumber DiophantinePoly(float x, int[] c)
        {
            int n = c.Length;

            ComplexNumber result = new ComplexNumber(0, 0);


            for (int i = 0; i < n; i++)
            {

                result += c[i] * Mathf.Pow(x, (n - i));
            }

            return result;


        }




        public static ComplexNumber DiophantinePoly(ComplexNumber z, DiophantinePolynomial p)
        {
            int n = p.k.Length;

            ComplexNumber result = new ComplexNumber(0, 0);


            for (int i = 0; i < n; i++)
            {

                result += p.k[i] * ComplexNumber.Pow(z, (n - i));
            }

            return result;

        }

        public static Polynomial RandomRealPolynomial(int n, float min, float max)
        {

            float[] c = new float[n + 1];

            for(int i = 0; i < n + 1; i++)
            {

                c[i] = UnityEngine.Random.Range(min, max);
            }

            ComplexNumber[] p = ComplexNumber.ComplexifyArray(c);

            return new Polynomial(p);


        }


        public static Polynomial RandomPolynomial(int n, float a)
        {
            ComplexNumber[] p = new ComplexNumber[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                p[i] = ComplexNumber.RandomComplexNumber(a);
                
            }

            return new Polynomial(p);

        }



    }



    public struct RealPolynomial
    {

        public float[] c;

        public int n;

        public RealPolynomial(float[] c)
        {

            this.c = c;

            this.n = c.Length - 1;

        }

    }


    public struct DiophantinePolynomial
    {

        public int[] k;

        public int n;

        public DiophantinePolynomial(int[] k)
        {

            this.k = k;

            this.n = k.Length - 1;

        }

    }


}
