using System;

namespace BinomialDistribution
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] ratio = Console.ReadLine().Split(' ');

            int numberOfSuccess = 3;
            int numberOfTries = 6;
            float successRatio = float.Parse(ratio[0]) / (float.Parse(ratio[0]) + float.Parse(ratio[1]));

            string result = BinomialComulative(numberOfSuccess, numberOfTries, successRatio).ToString("0.000");

            Console.WriteLine(result);

            Console.ReadLine();
        }

        private static float BinomialComulative(int numberOfSuccess, int numberOfTries, float successRatio)
        {
            float sum = 0;

            for (int i = numberOfSuccess; i <= numberOfTries; i++)
            {
                sum += Binomial(i, numberOfTries, successRatio);
            }

            return sum;
        }

        private static float Binomial(int numberOfSuccess, int numberOfTries, float successRatio)
        {
            float result = (float)(compination(numberOfTries, numberOfSuccess)
                           * Math.Pow(successRatio, numberOfSuccess) 
                           * Math.Pow((1 - successRatio), (numberOfTries - numberOfSuccess)));

            return result;
        }

        private static float compination(int n, int x)
        {
            float result = (float)factorial(n) / ((float)factorial(x) * factorial(n - x));
            return result;
        }

        private static int factorial(int x)
        {
            if (x <= 1) return 1;
            else return x * factorial(x - 1);
        }
    }
}
