using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComplexNumbers
{
    public abstract class ComplexNumberTest
    {

        public static System.Random randomNumber = new System.Random();


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

