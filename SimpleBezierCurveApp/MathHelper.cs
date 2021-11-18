namespace SimpleBezierCurveApp
{
    public static class MathHelper
    {
        /// <summary>
        /// The method returns the number of combinations. 
        /// The formula for N choose K is given as: C(n, k)= n!/[k!(n-k)!]
        /// </summary>
        /// <param name="n">is the total numbers</param>
        /// <param name="k">is the number of the selected item</param>
        /// <returns></returns>
        public static long C(long n, long k)
        {
            if (k >= 0 && k <= n)
            {
                long numerator = 1;
                long denominator = 1;
                long minValue = k < n - k ? k : n - k;

                for (long i = 1; i <= minValue; i++)
                {
                    numerator *= n;
                    denominator *= i;
                    n--;
                }

                return numerator / denominator;
            }
            else
            {
                return 0L;
            }
        }
    }
}
