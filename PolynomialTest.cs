using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComplexNumbers
{
    public abstract class PolynomialTest
    {

        public static float QuadPoly(float x, float alpha, float beta)
        {

            float result = (x - alpha) * (x - beta);

            return result;
        }

        public static float[] QuadCoefficients(float alpha, float beta)
        {

            float[] result = new float[2];

            result[0] = -(alpha + beta);

            result[1] = (alpha * beta);

            return result;
        }


    }

}

