using System;
namespace baekjun
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Cpnsole.ReadLine());
            string[] str = Console.ReadLine().Split();
            int[] dp = new int[num + 2];
            int[] p = new int[num + 2];

            for(int i = 1; i<=str.Length; i++)
            {
                p[i] = int.Parse(str[i - 1]);
            }
            for(int i = 1; i<= num; i++)
            {
                for(int j= 1; j<=i; j++)
                {
                    dp[i] = Math.Max(dp[i], dp[i - j] + p[j]);
                }
            }
            Console.Writedp[num]);
        }
    }
}