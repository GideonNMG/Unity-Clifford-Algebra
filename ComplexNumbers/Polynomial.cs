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

            this.c = c;

            this.n = c.Length - 1;

        }

        public static Polynomial RealPolynomial(float x, float[] a)
        {


            ComplexNumber[] c = ComplexNumber.ComplexifyArray(a);

            Polynomial result = new Polynomial(c);

            return result;

        }

        public static Polynomial RealPolynomial(float[] a)
        {


            ComplexNumber[] c = ComplexNumber.ComplexifyArray(a);

            Polynomial result = new Polynomial(c);

            return result;

        }


        public static Polynomial DiophantinePolynomial(int[] a)
        {
            int n = a.Length;

            ComplexNumber[] c = new ComplexNumber[n];
            for (int i = 0; i < n; i++)
            {

                c[i] = ComplexNumber.Complexify((float)a[i]);
            }

            Polynomial result = new Polynomial(c);

            return result;

        }


        public static ComplexNumber Poly(ComplexNumber z, Polynomial p)
        {


            int n = p.n;

            ComplexNumber P = new ComplexNumber(0, 0);

            for (int i = 0; i < n + 1; i++)
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

            for (int i = 0; i < n + 1; i++)
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


        public static Polynomial Derivative(Polynomial P)
        {
            int n = P.n;

            ComplexNumber[] p = new ComplexNumber[n];

            for (int i = 0; i < n; i++)
            {

                p[i] = (i + 1) * P.c[i + 1];
            }


            return new Polynomial(p);
        }

        public static Polynomial AntiDerivative(Polynomial P)
        {
            int n = P.n;

            ComplexNumber[] p = new ComplexNumber[n + 1];

            p[0] = new ComplexNumber(0, 0);


            for (int i = 1; i < n + 2; i++)
            {

                p[i] = P.c[i - 1] / (i);
            }


            return new Polynomial(p);
        }


        public static Polynomial Negative(Polynomial P)
        {

            int n = P.n;

            ComplexNumber[] p = new ComplexNumber[n + 1];

            for (int i = 0; i < n + 1; i++)
            {

                p[i] = -P.c[i];
            }


            return new Polynomial(p);

        }


        public static int GreaterN(Polynomial P1, Polynomial P2)
        {
            return Mathf.Max(P1.n, P2.n);

        }

        public static int LesserN(Polynomial P1, Polynomial P2)
        {
            return Mathf.Min(P1.n, P2.n);

        }

        public static ComplexNumber[] LongerArray(Polynomial P1, Polynomial P2)
        {

            return GreaterN(P1, P2) == P1.n ? P1.c : P2.c;
        }

        public static ComplexNumber[] ShorterArray(Polynomial P1, Polynomial P2)
        {

            return LesserN(P1, P2) == P1.n ? P1.c : P2.c;
        }




        public static Polynomial PolynomialAddition(Polynomial P1, Polynomial P2)
        {

            int m = LesserN(P1, P2);

            int n = GreaterN(P1, P2);

            ComplexNumber[] longerArray = LongerArray(P1, P2);


            ComplexNumber[] p = new ComplexNumber[n + 1];

            for (int i = 0; i <= m; i++)
            {

                p[i] = P1.c[i] + P2.c[i];
            }


            for (int i = m + 1; i < n + 1; i++)
            {

                p[i] = longerArray[i];
            }

            return new Polynomial(p);
        }


        public static Polynomial PolynomialAddition(Polynomial P, float c)
        {


            int n = P.n;



            ComplexNumber[] p = new ComplexNumber[n + 1];

            p[0] = P.c[0] + c;

            for (int i = 1; i < n + 1; i++)
            {

                p[i] = P.c[i];
            }


            return new Polynomial(p);
        }


        public static Polynomial ProductPolynomial(Polynomial P1, Polynomial P2)
        {
            int m1 = LesserN(P1, P2);

            int m2 = GreaterN(P1, P2);

            ComplexNumber[] p1 = ShorterArray(P1, P2);

            ComplexNumber[] p2 = LongerArray(P1, P2);

            ComplexNumber[] p = new ComplexNumber[m1 + m2 + 1];

            for (int i = 0; i <= m1; i++)
            {

                for (int j = 0; j < i; j++)
                {

                    p[i] = p1[i - j] * p2[j];
                }
            }

            for (int i = m1 + 1; i <= m2; i++)
            {


                for (int j = i - (m1 + 1); j <= m1; j++)
                {

                    p[i] += p2[i - j] * p1[j];
                }
            }

            for (int i = m2 + 1; i < m1 + m2 + 1; i++)
            {

                for (int j = i - (m2 + 1); j < m1; j++)
                {

                    p[i] += p2[i - j] * p1[j];

                }
            }

            return new Polynomial(p);

        }

        public static Polynomial ProductPolynomial(Polynomial P, float c)
        {
            int n = P.n + 1;
            ComplexNumber[] p = new ComplexNumber[n];

            for (int i =0;i<n;i++)
            {

                p[i] = P.c[i] * c;
            }

            return new Polynomial(p);
        }






        //Operator Overloads:
        public static Polynomial operator +(Polynomial operand) => operand;

        public static Polynomial operator +(Polynomial first, Polynomial second) =>
            PolynomialAddition(first, second);

        public static Polynomial operator +(Polynomial P, float c) =>
            PolynomialAddition(P, c);


        public static Polynomial operator +(float c, Polynomial P) =>
        PolynomialAddition(P, c);


        public static Polynomial operator +(Polynomial P, int i) =>
        PolynomialAddition(P, (float)i);


        public static Polynomial operator +(int i, Polynomial P) =>
        PolynomialAddition(P, (float)i);



        public static Polynomial operator -(Polynomial operand) => operand;

        public static Polynomial operator -(Polynomial first, Polynomial second) =>
            PolynomialAddition(first, Negative(second));

        public static Polynomial operator -(Polynomial P, float c) =>
            PolynomialAddition(P, -c);

        public static Polynomial operator -(float c, Polynomial P) =>
          PolynomialAddition(Negative(P), c);


        public static Polynomial operator -(Polynomial P, int i) =>
          PolynomialAddition(P, -(float)i);

        public static Polynomial operator -(int i, Polynomial P) =>
          PolynomialAddition(Negative(P), (float)i);

        public static Polynomial operator *(Polynomial P1, Polynomial P2) =>
        ProductPolynomial(P1, P2);

        public static Polynomial operator *(Polynomial P, float c) =>
         ProductPolynomial(P, c);

        public static Polynomial operator *( float c, Polynomial P) =>
        ProductPolynomial(P, c);






        //Equality Override:
        public override bool Equals(object P)
        {
            if (P == null)
            {
                return false;
            }

            var z = (Polynomial)P;


            return ( c == z.c);
          
         
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


        public static bool PolynomialEquality(Polynomial P1, Polynomial P2)
        {

            return (P1.c == P2.c);

        }


        public static bool operator ==(Polynomial P1, Polynomial P2)
        {
            return PolynomialEquality(P1, P2);

        }

        public static bool operator !=(Polynomial P1, Polynomial P2)
        {
            return !PolynomialEquality(P1, P2);


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
