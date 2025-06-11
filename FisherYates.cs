using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatrixMath
{
    public static class FisherYates
    {
        public static System.Random randomNumber = new System.Random();


        // FisherYates Shuffle Algorithm

        public static void Shuffle<T>(this IList<T> list)
        {

            int n = list.Count;

            if (n >= 1)
            {

                while (n > 1)
                {

                    n--;

                    int k = randomNumber.Next(n + 1);

                    T value = list[k];

                    list[k] = list[n];

                    list[n] = value;

                }

            }
            else
            {

                return;
            }

        }
    }

}

