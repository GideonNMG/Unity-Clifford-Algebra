using UnityEngine;
using System;

namespace ComplexNumbers
{
    public struct ComplexNumber  //Defined as "ComplexNumber" instead of just "Complex" to avoid potential clashed with System.Numerics namespace.
    {
        public float real;

        public float imaginary;   

        public float[] array;

        public ComplexNumber(float re, float im)
        {

            this.real = re;

            this.imaginary = im;

            this.array = new float[2] { real, imaginary};
                
        }


        //Complex Constants:
        public static ComplexNumber ImaginaryOne = new ComplexNumber(0, 1);

        public static readonly ComplexNumber _i = ComplexNumber.ImaginaryOne;

        public static readonly ComplexNumber _xi = new ComplexNumber(-1 / 2, Mathf.Sqrt(3) / 2); //Complex cube root of one.




        //Complex Operations:

        public static ComplexNumber ComplexFromArray(float[] array)
        {
            ComplexNumber result = new ComplexNumber(array[0], array[1]);

            return result;

        }


        public static ComplexNumber Complexify(float c)
        {

            return new ComplexNumber(c, 0);
        }


        public static ComplexNumber[] ComplexifyArray(float[] c)
        {
            int n = c.Length;

            ComplexNumber[] result = new ComplexNumber[n];

            for(int i = 0; i < n; i++)
            {
                result[i] = Complexify(c[i]);

            }

            return result;
          
        }


        public static ComplexNumber Conjugate(ComplexNumber z)
        {
            ComplexNumber result = new ComplexNumber(z.real, -z.imaginary);

            return result;

        }

        public static float SquareLength(ComplexNumber z)
        {

            float result = z.real * z.real + z.imaginary * z.imaginary;

            return result;
        }

        public static float LogSquareLength(ComplexNumber z)
        {
            float s = SquareLength(z);

            float result = Mathf.Log(s);

            return result;

        }


        public static float Modulus(ComplexNumber z)
        {
            float result = SquareLength(z);

            return Mathf.Sqrt(result);

        }


       

        //Returns the Argand angle in radians.
        public static float Arg(ComplexNumber z)
        {
            float result;

            if (z.real == 0)
            {
                if (z.imaginary > 0)
                {

                    result = Mathf.PI / 2;

                }


                else
                {
                    result = -Mathf.PI / 2;
                }



            }

            else if (z.real < 0)
            {

                if (z.imaginary < 0)
                {
                    result = Mathf.Atan(z.imaginary / z.real) - Mathf.PI;
                }

                else
                {

                    result = Mathf.Atan(z.imaginary / z.real) + Mathf.PI;
                }


            }

            else
            {
                result = Mathf.Atan(z.imaginary / z.real);

            }


            return result;

        }
        //Returns the Argand angle in degrees.
        public static float ArgDegrees(ComplexNumber z)
        {

            float r = Arg(z);

            float result = StaticFunctions.DegreesFromRads(r);

            return result;
        }

        public static ComplexNumber Log(ComplexNumber z)
        {
            float re = Mathf.Log(Modulus(z));

            float im = Arg(z);

            ComplexNumber result = new ComplexNumber(re, im);

            return result;

        }


        public static ComplexNumber Log(float x)
        {

            ComplexNumber result = new ComplexNumber();

            float ln;

            if (x > 0)
            {
                ln = Mathf.Log(x);

                result = new ComplexNumber(ln, 0);
               
            }

            else if (x < 0)
            {
                ln = Mathf.Log(-x);

                result = new ComplexNumber(ln, Mathf.PI / 2);

            }

            return result;
        }


        public static ComplexNumber Expi(float theta)
        {

            ComplexNumber result = new ComplexNumber(Mathf.Cos(theta), Mathf.Sin(theta));

            return result;
        }



        public static ComplexNumber Exp(ComplexNumber z)
        {
            float r = Mathf.Exp(z.real);

            ComplexNumber result = new ComplexNumber(r * Mathf.Cos(z.imaginary), r * Mathf.Sin(z.imaginary));

            return result;

        }


        public static ComplexNumber Pow(ComplexNumber z, float a)
        {
            float mod = Modulus(z);

            float arg = Arg(z);

            mod = Mathf.Pow(mod, a);

            arg *= a;


            ComplexNumber exp = Expi(arg);

            ComplexNumber result = new ComplexNumber(mod * exp.real, mod * exp.imaginary);

            return result;

        }


        public static ComplexNumber Pow(float a, ComplexNumber z)
        {

            float lna = Mathf.Log(a);

            float b = Mathf.Pow(a, z.real);

            float c = z.imaginary * lna;

            ComplexNumber result = Expi(c);

            result *= b;

            return result;

        }

        public static ComplexNumber Pow(int n, ComplexNumber z)
        {

            float a = (float)n;

            float lna = Mathf.Log(a);

            float b = Mathf.Pow(a, z.real);

            float c = z.imaginary * lna;

            ComplexNumber result = Expi(c);

            result *= b;

            return result;

        }



        public static ComplexNumber Pow(ComplexNumber z, int n)
        {

            float a = (float)n;

            return Pow(z, a);
        }




        public static ComplexNumber Pow(ComplexNumber z1, ComplexNumber z2)
        {
            float mod = Modulus(z1);

            float arg = Arg(z1);

            float a = Mathf.Pow(mod, z2.real);

            float b = Mathf.Exp(-z1.imaginary * arg);

            float c= z2.real * arg + z2.imaginary / 2 * LogSquareLength(z1);

            ComplexNumber result = Expi(c);

            result = a * b * result;

            return result;

        }



        public static ComplexNumber Sqrt(ComplexNumber z)
        {
            float mod = Modulus(z);

            float arg = Arg(z);

            mod = Mathf.Pow(mod, 1/2);

            arg *= 1/2;


            ComplexNumber exp = Expi(arg);

            ComplexNumber result = new ComplexNumber(mod * exp.real, mod * exp.imaginary);

            return result;

        }


        public static ComplexNumber Sqrt(float c)
        {
            ComplexNumber z = new ComplexNumber(c, 0);

            float mod = Modulus(z);

            float arg = Arg(z);

            mod = Mathf.Pow(mod, 1 / 2);

            arg *= 1 / 2;


            ComplexNumber exp = Expi(arg);

            ComplexNumber result = new ComplexNumber(mod * exp.real, mod * exp.imaginary);

            return result;

        }


        public static float[] ReArray(ComplexNumber[] Z)
        {

            int n = Z.Length;

            float[] result = new float[n];

            for(int i = 0; i < n; i++)
            {

                result[i] = Z[i].real;
            }

            return result;
        }


        public static float[] ImArray(ComplexNumber[] Z)
        {

            int n = Z.Length;

            float[] result = new float[n];

            for (int i = 0; i < n; i++)
            {

                result[i] = Z[i].imaginary;
            }

            return result;
        }



        //Operator Overloads:
        public static ComplexNumber operator +(ComplexNumber operand) => operand;

        public static ComplexNumber operator +(ComplexNumber first, ComplexNumber second) =>
            new ComplexNumber(first.real + second.real, first.imaginary + second.imaginary);

        public static ComplexNumber operator +(ComplexNumber z, float c) =>
         new ComplexNumber(z.real + c, z.imaginary);

        public static ComplexNumber operator +(float c, ComplexNumber z) =>
        new ComplexNumber(z.real + c, z.imaginary);


        public static ComplexNumber operator +(ComplexNumber z, int i) =>
         new ComplexNumber(z.real + (float)i, z.imaginary);


        public static ComplexNumber operator +(int i, ComplexNumber z) =>
        new ComplexNumber(z.real + (float)i, z.imaginary);



        //public static ComplexNumber operator -(ComplexNumber operand) => operand;

        public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second) =>
            new ComplexNumber(first.real - second.real, first.imaginary - second.imaginary);

        public static ComplexNumber operator -(ComplexNumber z, float c) =>
        new ComplexNumber(z.real - c, z.imaginary);

        public static ComplexNumber operator -(float c, ComplexNumber z) =>
        new ComplexNumber(c - z.real, -z.imaginary);


        public static ComplexNumber operator -(ComplexNumber z, int i) =>
        new ComplexNumber(z.real - (float)i, z.imaginary);

        public static ComplexNumber operator -(int i, ComplexNumber z) =>
        new ComplexNumber((float)i - z.real, -z.imaginary);

        public static ComplexNumber operator -(ComplexNumber z) =>
            new ComplexNumber(-1 * z.real, -1 * z.imaginary);




        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second) =>
        new ComplexNumber(first.real * second.real - first.imaginary * second.imaginary,
        first.real * second.imaginary + second.real * first.imaginary);

        public static ComplexNumber operator *(ComplexNumber z, float c) =>
        new ComplexNumber(z.real * c, z.imaginary * c);

        public static ComplexNumber operator *(float c, ComplexNumber z) =>
        new ComplexNumber(z.real * c, z.imaginary * c);

        public static ComplexNumber operator *(int i, ComplexNumber z) =>
        new ComplexNumber(z.real * (float)i, z.imaginary * (float)i);


        public static ComplexNumber operator *(ComplexNumber z, int i) =>
        new ComplexNumber(z.real * (float)i, z.imaginary * (float)i);



        public static ComplexNumber operator /(ComplexNumber top, ComplexNumber bottom) =>


        new ComplexNumber((top * Conjugate(bottom)).real / Modulus(bottom),
        (top * Conjugate(bottom)).imaginary / Modulus(bottom));


        public static ComplexNumber operator /(ComplexNumber z, float c) =>

            new ComplexNumber(z.real / c, z.imaginary / c);


        public static ComplexNumber operator /(float top, ComplexNumber bottom) =>


        new ComplexNumber((top * Conjugate(bottom)).real / Modulus(bottom),
        (top * Conjugate(bottom)).imaginary / Modulus(bottom));

      
            


        //Equality Override:
        public override bool Equals(object number)
        {
            if (number == null)
            {
                return false;
            }

            var z = (ComplexNumber)number;
            return (real == z.real && imaginary == z.imaginary);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


        public static bool ComplexEquality(ComplexNumber z1, ComplexNumber z2)
        {
            if (z1.real == z2.real && z1.imaginary == z2.imaginary)
            {

                return true;
            }

            else
            {

                return false;
            }

        }


        public static bool operator ==(ComplexNumber first, ComplexNumber second)
        {
            return ComplexEquality(first, second);

        }

        public static bool operator !=(ComplexNumber first, ComplexNumber second)
        {
            return !ComplexEquality(first, second);


        }

      
        //Random ComplexNumbers:

        public static float[] RandomPair(float min, float max)
        {
            float[] pair = new float[2];

            pair[0] = UnityEngine.Random.Range(min, max);

            pair[1] = UnityEngine.Random.Range(min, max);

            return pair;

        }

        public static float[] RandomPair(float a)
        {
            float[] pair = new float[2];

            pair[0] = UnityEngine.Random.Range(-a, a);

            pair[1] = UnityEngine.Random.Range(-a, a);

            return pair;

        }


        public static ComplexNumber RandomComplexNumber(float min, float max)
        {
            float[] pair = RandomPair(min, max);

            ComplexNumber result = ComplexNumber.ComplexFromArray(pair);

            return result;

        }

        public static ComplexNumber RandomComplexNumber(float a)
        {
            float[] pair = RandomPair(a);


            ComplexNumber result = ComplexNumber.ComplexFromArray(pair);

            return result;

        }

    }


}
