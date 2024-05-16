행렬 - 백준 1080번

문제)
0과 1로만 이루어진 행렬 A와 행렬 B가 있다. 이때, 행렬 A를 행렬 B로 바꾸는데 필요한 연산의 횟수의 최솟값을 구하는 프로그램을 작성하시오.

행렬을 변환하는 연산은 어떤 3×3크기의 부분 행렬에 있는 모든 원소를 뒤집는 것이다. (0 → 1, 1 → 0)

입력)
첫째 줄에 행렬의 크기 N M이 주어진다. N과 M은 50보다 작거나 같은 자연수이다. 둘째 줄부터 N개의 줄에는 행렬 A가 주어지고, 그 다음줄부터 N개의 줄에는 행렬 B가 주어진다.

출력)
첫째 줄에 문제의 정답을 출력한다. 만약 A를 B로 바꿀 수 없다면 -1을 출력한다.

답안)
using System;

class Q1080 {
    
    static int N, M;
    static int [,] mA, mB;
    
  static void Main() {
      
      string[] row_col = Console.ReadLine().Split();
      
      N = int.Parse(row_col[0]);
      M = int.Parse(row_col[1]);
      mA = new int[N, M];
      mB = new int[N, M];
    
      for (int i=0; i<N; i++) {
          string row = Console.ReadLine();
          for(int j=0; j<M; j++) {
              mA[i, j] = row[j]-'0';
          }
      }
      
      for (int i=0; i<N; i++) {
          string row = Console.ReadLine();
          for(int j=0; j<M; j++) {
              mB[i, j] = row[j]-'0';
          }
      }
      
      Console.WriteLine(Matrix_Transform());
    
  }
  
  static void Matrix_Flip(int x, int y) {
      
    for (int i=0; i<3; i++)
    {
        for (int j=0; j<3; j++)
        {
            mA[x+i, y+j] = 1-mA[x+i, y+j];
        }
    }
    
    }
  
  static int Matrix_Transform() {
      
        int cnt = 0;

        for (int i=0; i<=N-3; i++)
        {
            for (int j=0; j<=M-3; j++)
            {
                if (mA[i, j] != mB[i, j])
                {
                    Matrix_Flip(i, j);
                    cnt++;
                }
            }
        }

        for (int i=0; i<N; i++)
        {
            for (int j=0; j<M; j++)
            {
                if (mA[i, j] != mB[i, j])
                {
                    return -1;
                }
            }
        }

        return cnt;
        
    }
}
