using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortAlgorithms
{

    public static class Algorithms 

    {

        public static System.Random randomNumber = new System.Random();


        // Fisher Yates Shuffle Algorithm

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



        public static void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
      
        }



        public static int[] BubbleSortArray(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;

        }



        // Returns a sorted copy of the original array without changing the input. 
        public static int[] SafeBubbleSortArray(int[] array)
        {
            int n = array.Length;

            int[] result = new int[n];

            for (int k = 0; k < n; k++)
            {

                result[k] = array[k];
            }

            for (int i = 0; i < n - 1; i++)
            {

                for (int j = 0; j < n - i - 1; j++)
                {


                    if (result[j] > result[j + 1])
                    {
                        int temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;

        }



        public static float SortSignature(int[] array)
        {
              int k = 0;

              int n = array.Length;

              
          
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        k++;
                    }
                }
            }

            return Mathf.Pow(-1, k % 2);

        }




        public static float SafeSortSignature(int[] a)
        {
            int k = 0;

            int n = a.Length;

            int[] array = new int[n];

            for(int l =0; l < n; l++)
            {

                array[l] = a[l];
            }


            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        k++;
                    }
                }
            }

            return Mathf.Pow(-1, k % 2);

        }




        public static void Exchange<T>(T a, T b)
        {


            T temp = a;

            a = b;

            b = temp;

        }



        public static void Exchange<T>(T[] a, int i, int j)
        {

            T temp = a[i];

            a[i] = a[j];

            a[j] = temp;


        }


        public static int Partition(int[] list, int lo, int hi)
        {


            int pivot = list[lo];

            while (true)
            {
                while (list[lo] < pivot)
                {
                    lo++;
                }


                while (list[hi] > pivot)
                {

                    hi--;
                }



                if (lo < hi)
                {

                    if (list[lo] == list[hi])
                    {

                        return hi;
                    }

                    Exchange(list, lo, hi);
                }

                else
                {
                    return hi;

                }

            }

        }




        public static int Partition(float[] list, int lo, int hi)
        {


            float pivot = list[lo];

            while (true)
            {
                while (list[lo] < pivot)
                {
                    lo++;
                }


                while (list[hi] > pivot)
                {

                    hi--;
                }


                if (lo < hi)
                {

                    if (list[lo] == list[hi])
                    {

                        return hi;
                    }

                    Exchange(list, lo, hi);
                }

                else
                {
                    return hi;

                }

            }

        }


        

        public static void QuickSort(int[] a, int lo, int hi)
        {

            if (lo < hi)
            {

                int pivot = Partition(a, lo, hi);

                if (pivot > 1)
                {

                    QuickSort(a, lo, pivot - 1);


                }


                if (pivot +1 < hi)
                {

                    QuickSort(a, pivot + 1, hi);

                }

            }

        }




        public static void QuickSort(float[] a, int lo, int hi)
        {

            if (lo < hi)
            {

                int pivot = Partition(a, lo, hi);

                if (pivot > 1)
                {

                    QuickSort(a, lo, pivot - 1);


                }


                if (pivot + 1 < hi)
                {

                    QuickSort(a, pivot + 1, hi);

                }

            }


        }


    }

}
