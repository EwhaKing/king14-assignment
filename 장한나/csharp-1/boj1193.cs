//백준 실버 5
//1193. 분수찾기

public static class Program1
{
    public static void Main(string[] args)
    {
        string X = Console.ReadLine();
        int x = int.Parse(X);

        int lineCount = 1;

        while (x > lineCount)
        {
            x -= lineCount;
            lineCount++;
        }

        if (lineCount % 2 == 1)
            Console.Write($"{lineCount - x + 1}/{x}");
        else
            Console.Write($"{x}/{lineCount - x + 1}");
    }
}
