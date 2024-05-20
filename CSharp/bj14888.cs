using System;
using System.Collections.Generic;

class Program
{
    static int[] Calc(int op, int op1, int op2)
    {
        switch (op)
        {
            case 0: // 더하기
                return new int[] { op1 + op2 };
            case 1: // 빼기
                return new int[] { op1 - op2 };
            case 2: // 곱하기
                return new int[] { op1 * op2 };
            case 3: // 나누기
                if (op2 != 0)
                    return new int[] { op1 / op2 };
                break;
        }
        // 0으로 나누거나 잘못된 연산자인 경우 null 반환
        return null;
    }
  
    // 백트래킹을 통해 가능한 모든 경우의 수를 탐색
    static void BackTracking(int value, int index, int n, ref int vmax, ref int vmin, List<int> nums, List<int> op)
    {
        // 모든 피연산자를 사용한 경우
        if (index == n)
        {
            vmax = Math.Max(vmax, value);
            vmin = Math.Min(vmin, value);
            return;
        }

        // 아직 사용하지 않은 피연산자가 있는 경우
        for (int i = 0; i < 4; i++)
        {
            if (op[i] == 0)
                continue;

            op[i]--;
            int[] result = Calc(i, value, nums[index]);
            if (result != null)
            {
                int nextValue = result[0];
                BackTracking(nextValue, index + 1, n, ref vmax, ref vmin, nums, op);
            }
            op[i]++;
        }
    }

    static Tuple<int, int> Solution(int n, List<int> nums, List<int> op)
    {
        int vmax = int.MinValue, vmin = int.MaxValue;
        BackTracking(nums[0], 1, n, ref vmax, ref vmin, nums, op);
        return Tuple.Create(vmax, vmin);
    }

    static void Main(string[] args)
    {
        // 입력 받기
        int n = int.Parse(Console.ReadLine());
        List<int> nums = new List<int>();
        List<int> op = new List<int>();

        string[] numsStr = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            nums.Add(int.Parse(numsStr[i]));
        }

        string[] opStr = Console.ReadLine().Split(' ');
        for (int i = 0; i < 4; i++)
        {
            op.Add(int.Parse(opStr[i]));
        }
        //문제 풀이 & 결과 출력
        var result = Solution(n, nums, op);
        Console.WriteLine(result.Item1);
        Console.WriteLine(result.Item2);
    }
}
