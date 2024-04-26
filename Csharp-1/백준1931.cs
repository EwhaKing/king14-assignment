using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int endPoint = 0;
        int answer = 0;
        int[][] lectures = new int[n][];

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            lectures[i] = new int[] { a, b };
        }

        Array.Sort(lectures, (x, y) => {
            if (x[1] == y[1]) return x[0].CompareTo(y[0]);
            return x[1].CompareTo(y[1]);
        });

        foreach (int[] lecture in lectures)
        {
            int start = lecture[0];
            int end = lecture[1];
            if (endPoint <= start)
            {
                answer++;
                endPoint = end;
            }
        }
        Console.WriteLine(answer);
    }
}
