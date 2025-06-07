using UnityEngine;
using System;
using System.Numerics;

namespace MatrixMath
{
    public  static class Polynomials
    {

       public static readonly Complex _i = Complex.ImaginaryOne;

        public static readonly Complex _xi = new Complex(-1 / 2, Mathf.Sqrt(3) / 2);

        public static Complex[] QuadraticZeroes(float a, float b, float c)
        {

            Complex[] result = new Complex[2];

            Complex r = DiscriminantRoot(a, b, c);

            result[0] = (-b + r) / 2f * a;

            result[1] = (-b - r) / 2f * a;

            return result;
        }

        public static Complex QuadraticZeroes(float a, float b, float c, int k)
        {

            int index = k % 2;

            Complex[] zeroes = new Complex[2];

            Complex r = DiscriminantRoot(a, b, c);

            zeroes[0] = (-b + r) / 2f * a;

            zeroes[1] = (-b - r) / 2f * a;

            Complex result = zeroes[index];

            return result;
        }


        public static float[] RealQuadraticZeroes(float a, float b, float c)
        {
            float[] result = new float[2];

            float disc = Discriminant(a, b, c);

            if (CheckRealRoots(a, b, c))
            {

           
                float r = Mathf.Sqrt(Discriminant(a, b, c));

                result[0] = (-b + r) / 2f * a;

                result[1] = (-b - r) / 2f * a;

                return result;
            }

            else
            {

                Debug.LogWarning("No Real Roots. Returning discriminant.");

                result[0] = disc;

                result[1] = disc;

                return result;
            }

        }


        public static bool CheckRealRoots(float a, float b, float c)
        {
            if (Discriminant(a, b, c) >= 0)
            {
                return true;

            }

            else
            {

                return false;
            }

        }

     
        public static float Discriminant(float a, float b, float c)
        {

            float result = (b * b - 4 * a * c);

            return result;
        }



        public static Complex DiscriminantRoot(float a, float b, float c)
        {

            Complex result = Complex.Sqrt(b * b - 4 * a * c);

            return result;
        }


        public static float RealPart(Complex z)
        {

            float result = (float)z.Real;

            return result;
        }

        public static float ImaginaryPart(Complex z)
        {

            float result = (float)z.Imaginary;

            return result;
        }



        public static float CubeRoot(float a)
        {

            float result = Mathf.Pow(a, 1 / 3);

            return result;

        }


    
        public static Complex CubeRoot(Complex z)
        {

            Complex result = Complex.Pow(z, 1 / 3);

            return result;
        }



        public static Complex ComplexCubeRoot(float a)
        {

            Complex z = MakeFloatComplex(a);

            Complex result = Complex.Pow(z, 1 / 3);

            return result;
        }


        public static Complex MakeFloatComplex(float a)
        {

            Complex result = new Complex(a, 0);

            return result;
        }


        public static Complex[] CubicZeroes(float a, float b, float c, float d)
        {

            Complex[] result = new Complex[3];


            float delta0 = b * b - 3f * a * c;

            float delta1 = 2 * Mathf.Pow(b, 3) - 9f * a * b * c + 27f * a * a * d;

            float gamma = Mathf.Sqrt(delta1 * delta1 - 4f * Mathf.Pow(delta0, 3));

            float beta = CubeRoot(delta1 / 2f + gamma / 2f);

            if (beta == 0)
            {

                beta = CubeRoot(delta1 / 2f - gamma / 2f);
            }

            for(int k = 0; k < 3; k++)
            {

                Complex Xi_k = Complex.Pow(_xi, k);

                result[k] = (-1 / 3f * a) * ( b + (Xi_k * beta) + delta0/ (Xi_k * beta) );
            }

            return result;
          
        }

    }

}


