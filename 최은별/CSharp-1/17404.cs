using System;

class Program
{
    static void Main()
    {
        // 입력
        string? input = Console.ReadLine();
        int n = int.Parse(input); // 집의 수

        int[,] costs = new int[n, 3]; // 각 집을 칠하는 비용 저장 배열
        for (int i = 0; i < n; i++) // 각 비용
        {   
            string? line = Console.ReadLine();
            string[] rgb = line.Split();
            costs[i, 0] = int.Parse(rgb[0]); // 빨강으로 칠하는 비용
            costs[i, 1] = int.Parse(rgb[1]); // 초록으로 칠하는 비용
            costs[i, 2] = int.Parse(rgb[2]); // 파랑으로 칠하는 비용
        }
        
        // 연산
        const int INF = int.MaxValue / 2;
        int result = INF; // 최소 비용 초기값 최대 설정
        int[,] dp = new int[n, 3]; // DP 배열 생성

        // 첫 번째 집의 색깔 고정, 각 경우 계산
        for (int h1 = 0; h1 < 3; h1++)
        {
            // 첫 번째 집의 색깔 고정, 나머지 집 초기화
            for (int color = 0; color < 3; color++)
            {
                if (color == h1)
                    dp[0, color] = costs[0, color];
                else
                    dp[0, color] = INF;
            }

            // DP
            for (int i = 1; i < n; i++) // i번째 집 색칠, 시작색 제외 비교
            {
                dp[i, 0] = Math.Min(dp[i - 1, 1], dp[i - 1, 2]) + costs[i, 0]; // 빨강
                dp[i, 1] = Math.Min(dp[i - 1, 0], dp[i - 1, 2]) + costs[i, 1]; // 초록
                dp[i, 2] = Math.Min(dp[i - 1, 0], dp[i - 1, 1]) + costs[i, 2]; // 파랑
            }

            // 마지막 집의 색깔 != 첫 번째 집의 색깔, 최소 비용 갱신
            for (int hn = 0; hn < 3; hn++)
            {
                if (hn != h1)
                {
                    result = Math.Min(result, dp[n - 1, hn]);
                }
            }
        }

        // 출력
        Console.WriteLine(result);
    }
}
