using System;
using System.Collections.Generic;
using System.Text;

namespace SIMSrq
{
    static class Calc
    {
        static Random rnd = new Random();
        public static double mean(double[] arr, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
                sum = sum + arr[i];
            return (float)sum / n;
        }
        public static double standardDeviation(double[] arr, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
                sum = sum + (arr[i] - mean(arr, n)) * (arr[i] - mean(arr, n));
            return (float)Math.Sqrt(sum / (n - 1));
        }
        public static double coefficientOfVariation(double[] arr, int n)
        {            
            return (float)(standardDeviation(arr, n) / mean(arr, n));
        }
        public static double correlationCoefficient(List<double> arr)
        {
            List<double> X = arr;
            X.RemoveAt(X.Count-1);

            List<double> Y = arr;
            Y.RemoveAt(0);

            int n = X.Count;

            double sum_X = 0, sum_Y = 0, sum_XY = 0;
            double squareSum_X = 0, squareSum_Y = 0;

            for (int i = 0; i < n; i++)
            {
                sum_X = sum_X + X[i];
                sum_Y = sum_Y + Y[i];

                sum_XY = sum_XY + X[i] * Y[i];
                squareSum_X = squareSum_X + X[i] * X[i];
                squareSum_Y = squareSum_Y + Y[i] * Y[i];
            }

            double corr = (double)(n * sum_XY - sum_X * sum_Y) / (double)(Math.Sqrt((n * squareSum_X - sum_X * sum_X) * (n * squareSum_Y - sum_Y * sum_Y)));
            return corr;
        }
        public static double ExpDist(double param)
        {
            double A = rnd.NextDouble();
            return Math.Abs(-Math.Log(A) / param);
        }
    }
}
