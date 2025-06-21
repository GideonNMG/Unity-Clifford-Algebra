using UnityEngine;
using System;

namespace ComplexNumbers
{
    public struct ComplexNumber
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

        public static ComplexNumber operator +(ComplexNumber operand) => operand;

        public static ComplexNumber operator +(ComplexNumber first, ComplexNumber second) =>
            new ComplexNumber(first.real + second.real, first.imaginary + second.imaginary);

        public static ComplexNumber operator + (ComplexNumber z, float c) =>
         new ComplexNumber(z.real + c, z.imaginary );

        public static ComplexNumber operator +(float c, ComplexNumber z) =>
        new ComplexNumber(z.real + c, z.imaginary);


        public static ComplexNumber operator - (ComplexNumber operand) => operand;

        public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second) =>
            new ComplexNumber(first.real - second.real, first.imaginary - second.imaginary);

        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second) =>
        new ComplexNumber(first.real * second.real - first.imaginary * second.imaginary,
        first.real * second.imaginary + second.real * first.imaginary);

        public static ComplexNumber operator * (ComplexNumber z, float  c) =>
        new ComplexNumber(z.real * c ,  z.imaginary * c);

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
            if(z1.real == z2.real && z1.imaginary == z2.imaginary)
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

        public static ComplexNumber Complexify(float c)
        {

            return new ComplexNumber(c, 0);
        }

        public static ComplexNumber Conjugate(ComplexNumber z)
        {
            ComplexNumber result = new ComplexNumber(z.real, -z.imaginary);

            return result;

        }

        public static float SquareLength(ComplexNumber z)
        {

            ComplexNumber zbar = Conjugate(z);

            float result = (z * zbar).real;

            return result;
        }


        public static float Modulus(ComplexNumber z)
        {
            float result = SquareLength(z);

            return Mathf.Sqrt(result);

        }
        public static ComplexNumber ImaginaryOne = new ComplexNumber(0, 1);



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

    }


}
