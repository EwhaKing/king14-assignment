//백준 실버 5
//4673. 셀프 넘버

using System;

public static class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 10001; i++)
        {
            if (RevD(i) == -1) Console.WriteLine(i);
        }
    }

    public static int D(int n)
    {
        int sum = n;
        while (n != 0)
        {
            sum += n % 10;
            n /= 10;
        }

        return sum;
    }

    public static int RevD(int dn)
    {
        for (int i = 0; i < 10001; i++)
        {
            if (D(i) == dn) return i;
        }

        return -1;
    }
}
