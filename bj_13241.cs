using System;

class Program
{
    static long GCD(long a, long b){ // a와 b의 최대공약수 구하기
        if(b == 0)
            return a;

        return GCD(b, a % b);
    }

    static void Main(string[] args)
    {
        long A, B, gcd, lcm;
        string input = Console.ReadLine();    // 문자열 받기

        string[] numbers = input.Split(' ');  // 문자열을 공백으로 구분하여 배열로 만들기
        A = int.Parse(numbers[0]);     // 첫 번째 값 정수 변환
        B = int.Parse(numbers[1]);     // 두 번째 값 정수 변환

        gcd = GCD(A, B); // 최대공약수 구하기
        lcm = A * B / gcd; // 최소공배수 구하기

        Console.WriteLine(lcm.ToString()); // 결과 출력
    }
}