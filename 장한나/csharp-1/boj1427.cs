//백준 실버 5
//1427. 소트인사이드


    class Program
    {
        static void Main(string[] args)
        {

            var num = Console.ReadLine()!;

            var sortedNum = new string(num.OrderByDescending(c => c).ToArray());

            Console.WriteLine(sortedNum);

        }
    }

