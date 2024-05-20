using System;
class OpManager
{
    public static int Add(int a, int b) { return a+b; }
    public static int Sub(int a, int b) { return a-b;}
    public static int Mul(int a, int b) { return a*b; }
    public static int Div(int a, int b)
    {
        if(b!=0)
            return a/b;
        return 0;
    }
}

class Test
{
    public delegate int intOp(int a, int b);
    static void Main()
    {
        intOp[] arOp = new intOp[4];

        arOp[0] += OpManager.Add;
        arOp[1] += OpManager.Sub;
        arOp[2] += OpManager.Mul;
        arOp[3] += OpManager.Div;

        Console.Write("숫자 2개를 입력하시오.\n");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("수행할 연산을 고르시오. (1. 덧셈 2. 뺄셈 3. 곱셈 4. 나눗셈)\n");
        int o = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("결과 : " + arOp[o - 1](a, b));
    }
}