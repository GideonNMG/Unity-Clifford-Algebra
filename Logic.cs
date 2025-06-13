using UnityEngine;
using System.Collections;


namespace MatrixMath
{
    public static class Logic
    {
        public static bool XorValue(float a, float b, float x)
        {

            if ((a == x && b != x) || (a!=x && b==x))
            {

                return true;
            }

            else
            {
                return false;

            }

        }



        public static bool XorValue(float[] a, float[] b, int i, float x)
        {

            if ((a[i] == x && b[i] != x) || (a[i] != x && b[i] == x))
            {

                return true;
            }

            else
            {
                return false;

            }

        }


        public static bool XorValue(float[] a, float[] b, int i) // If no value is given explicity, the value will default to zero. 
        {

            if (a[i] == 0f && b[i] != 0f)
            {

                return true;
            }

            else
            {
                return false;

            }

        }


        public static bool XorValue(int[] a, int[] b, int i) // If no value is given explicity, the value will default to zero. 
        {

            if (a[i] == 0f && b[i] != 0f)
            {

                return true;
            }

            else
            {
                return false;

            }

        }


        public static bool Nand(bool a, bool b)
        {

            if (a && b)
            {

                return false;
            }

            else
            {

                return true;
            }
        }



        public static bool Nor(bool a, bool b)
        {

            if (!a && !b)
            {

                return true;
            }

            else
            {

                return false;
            }
        }

    }

}

