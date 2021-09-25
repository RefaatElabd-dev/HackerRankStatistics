using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace InterquartileRange
{
    class Result
    {

        /*
         * Complete the 'interQuartile' function below.
         *
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY values
         *  2. INTEGER_ARRAY freqs
         */

        public static void interQuartile(List<int> values, List<int> freqs)
        {
            // Print your answer to 1 decimal place within this function

            //collect S Array
            List<int> S = new List<int>();

            for(int i = 0; i < values.Count; i++)
            {
                for (int j = 0; j < freqs[i]; j++)
                {
                    S.Add(values[i]);
                }
            }

            S.Sort();

            foreach (var item in S)
            {
                Console.WriteLine(item);
            }
            //Get Q1
            double Q1 = GetQ1(S);
            //Get Q2
            double Q3 = GetQ3(S);
            //Get interQuartile
            double interQuartile = Q3 - Q1;
            if (interQuartile != (int)interQuartile)
                Console.WriteLine(interQuartile);
            else
                Console.WriteLine(interQuartile + ".0");
        }
        private static double GetQ1(List<int> arr)
        {
            int length = arr.Count / 2;

            List<int> FirstHalf = new List<int>();

            for (int i = 0; i < length; i++)
            {
                FirstHalf.Add(arr[i]);
            }

            return GetMedian(FirstHalf);
        }

        private static double GetQ3(List<int> arr)
        {
            int length = arr.Count;

            int startPoint = 0;
            if (length % 2 == 0)
                startPoint = length / 2;
            else
                startPoint = (length / 2) + 1;
            
            List<int> SecondHalf = new List<int>();

            for (int i = startPoint; i < length; i++)
            {
                SecondHalf.Add(arr[i]);
            }

            return GetMedian(SecondHalf);
        }
        private static double GetMedian(List<int> arr)
        {
            double median = 0;
            int length = arr.Count;

            if(length % 2 == 0)
            {
                median = GetOneFloatingPoint((arr[length/2] + arr[(length / 2) - 1]) / 2f);
            }
            else
            {
                median = arr[length / 2];
            }

            return median;
        }

        private static double GetOneFloatingPoint(double number)
        {
            return (double)( (int)(number * 10) ) / 10;
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> val = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(valTemp => Convert.ToInt32(valTemp)).ToList();

            List<int> freq = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(freqTemp => Convert.ToInt32(freqTemp)).ToList();

            Result.interQuartile(val, freq);

            Console.ReadLine();
        }
    }
}



