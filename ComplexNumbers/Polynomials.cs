using UnityEngine;
using System;


namespace ComplexNumbers
{
    public  static class Polynomials
    {
      
        public static ComplexNumber[] QuadraticZeroes(float a, float b, float c)
        {

            ComplexNumber[] result = new ComplexNumber[2];

            ComplexNumber r = DiscriminantRoot(a, b, c);

            result[0] = (-ComplexNumber.Complexify(b) + r) / 2f * a;

            result[1] = (-ComplexNumber.Complexify(b)- r) / 2f * a;

            return result;
        }

        public static ComplexNumber[] QuadraticZeroes(float a, float b, ComplexNumber c)
        {

            ComplexNumber[] result = new ComplexNumber[2];

            ComplexNumber r = DiscriminantRoot(a, b, c);

            result[0] = (-ComplexNumber.Complexify(b) + r) / 2f * a;

            result[1] = (-ComplexNumber.Complexify(b) - r) / 2f * a;

            return result;
        }


        public static ComplexNumber[] QuadraticZeroes(float a, ComplexNumber b, float c)
        {

            ComplexNumber[] result = new ComplexNumber[2];

            ComplexNumber r = DiscriminantRoot(a, b, c);

            result[0] = (-b + r) / 2f * a;

            result[1] = (-b - r) / 2f * a;

            return result;
        }



        public static ComplexNumber[] QuadraticZeroes(ComplexNumber a, ComplexNumber b, ComplexNumber c)
        {

            ComplexNumber[] result = new ComplexNumber[2];

            ComplexNumber r = DiscriminantRoot(a, b, c);

            result[0] = (-b + r) / 2f * a;

            result[1] = (-b - r) / 2f * a;

            return result;
        }

        public static ComplexNumber QuadraticZeroes(float a, float b, float c, int k)
        {

            int index = k % 2;

            ComplexNumber[] zeroes = new ComplexNumber[2];

            ComplexNumber r = DiscriminantRoot(a, b, c);

            zeroes[0] = (-b + r) / 2f * a;

            zeroes[1] = (-ComplexNumber.Complexify(b) - r) / 2f * a;

            ComplexNumber result = zeroes[index];

            return result;
        }


        public static ComplexNumber QuadraticZeroes(ComplexNumber a, ComplexNumber b, ComplexNumber c, int k)
        {

            int index = k % 2;

            ComplexNumber[] zeroes = new ComplexNumber[2];

            ComplexNumber r = DiscriminantRoot(a, b, c);

            zeroes[0] = (-b + r) / 2f * a;

            zeroes[1] = (-b - r) / 2f * a;

            ComplexNumber result = zeroes[index];

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


        public static ComplexNumber Discriminant(ComplexNumber a, ComplexNumber b, ComplexNumber c)
        {

            ComplexNumber result = (b * b - 4 * a * c);

            return result;
        }



        public static ComplexNumber DiscriminantRoot(float a, float b, float c)
        {

            ComplexNumber result = ComplexNumber.Sqrt(b * b - 4 * a * c);

            return result;
        }


        public static ComplexNumber DiscriminantRoot(float a, ComplexNumber b, float c)
        {

            ComplexNumber result = ComplexNumber.Sqrt(b * b - 4 * a * c);

            return result;
        }

        public static ComplexNumber DiscriminantRoot(float a, float b, ComplexNumber c)
        {

            ComplexNumber result = ComplexNumber.Sqrt(b * b - 4 * a * c);

            return result;
        }



        public static ComplexNumber DiscriminantRoot(ComplexNumber a, ComplexNumber b, ComplexNumber c)
        {

            ComplexNumber result = ComplexNumber.Sqrt(b * b - 4 * a * c);

            return result;
        }



        public static float CubeRoot(float a)
        {

            float result = Mathf.Pow(a, 1 / 3);

            return result;

        }


    
        public static ComplexNumber CubeRoot(ComplexNumber z)
        {

            ComplexNumber result = ComplexNumber.Pow(z, 1 / 3);

            return result;
        }



        public static ComplexNumber ComplexNumberCubeRoot(float a)
        {

            ComplexNumber z = ComplexNumber.Complexify(a);

            ComplexNumber result = ComplexNumber.Pow(z, 1 / 3);

            return result;
        }


        public static ComplexNumber[] CubicZeroes(float a, float b, float c, float d)
        {

            ComplexNumber[] result = new ComplexNumber[3];


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

                ComplexNumber Xi_k = ComplexNumber.Pow(ComplexNumber._xi, k);

                result[k] = (-1 / 3f * a) * ( b + (Xi_k * beta) + delta0/ (Xi_k * beta) );
            }

            return result;
          
        }

           

    }

}


