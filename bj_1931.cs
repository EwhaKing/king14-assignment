using System;
using System.Linq;
namespace PracticeAlgo
{
    class Program
    {
        static int N;
        static void Main(string[] args)
        {
            using (var prnt = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                (long, long)[] Time;
                N = int.Parse(Console.ReadLine());
                Time = new (long, long)[N];
                for (int i = 0; i < N; i++)
                {
                    var buf = Console.ReadLine().Split(' ');
                    Time[i] = (long.Parse(buf[0]), long.Parse(buf[1]));
                }
               var timeSort = Time.OrderBy(x => x.Item2).ThenBy(x => x.Item1).ToArray();
                (long, long) current =(0,0);
                int count = 0;
                for (int i = 0; i < N; i++)
                {
                    if (timeSort[i].Item1 >= current.Item2)
                    {
                        current = timeSort[i];
                        count++;
                    }
                }
                prnt.WriteLine(count);
            }
        }
    }
}
