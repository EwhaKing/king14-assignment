using System;

// 이벤트 정의 클래스
public class Calculator
{
    // 계산을 위한 델리게이트 정의
    public delegate void CalculationPerformed(int result);

    // 이벤트 정의
    public event CalculationPerformed CalculationFinished;

    // 덧셈 메서드
    public void Add(int a, int b)
    {
        int result = a + b;
        OnCalculaionFinished(result);
    }

    // 뺄셈 메서드
    public void Subtract(int a, int b)
    {
        int result = a - b;
        OnCalculaionFinished(result);
    }

    // 이벤트를 발생시키는 메서드
    protected virtual void OnCalculaionFinished(int result)
    {
        CalculationFinished?.Invoke(result);
    }
}

public class CalculatorDisplay
{
    // 이벤트를 처리하는 메서드
    public void ShowResult(int result)
    {
        Console.WriteLine($"계산 결과 : {result}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 계산기 객체 생성
        Calculator calculator = new Calculator();
        
        // 결과를 표시할 객체 생성
        CalculatorDisplay display = new CalculatorDisplay();

        // 계산기 결과를 출력 객체에 구독
        calculator.CalculationFinished += display.ShowResult;

        // 계산 수행
        calculator.Add(5, 3);
        calculator.Subtract(10, 7);
    }
}