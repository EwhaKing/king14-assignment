using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class king_assignment_cs1
    {
        static int n, k;
        static int[] num = new int[1000001];

        static int GetMax(List<int> arr, int l, int r)
        {
            int cnt = 0;
            while (r < n)
            {
                if (num[arr[r]] != k)
                {
                    num[arr[r]]++;
                    r++;
                }
                else
                {
                    num[arr[l]]--;
                    l++;
                }
                cnt = Math.Max(cnt, r - l);
            }
            return cnt;
        }

        static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            k = int.Parse(input[1]);

            List<int> arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int maxCnt = GetMax(arr, 0, 0);

            Console.WriteLine(maxCnt);
        }
    }
}
