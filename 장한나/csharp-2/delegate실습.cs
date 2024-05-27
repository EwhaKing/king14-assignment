using System;

// 델리게이트 선언
public delegate void Notify(string message);

public class Publisher
{
    // 이벤트 선언
    public event Notify OnNotify;

    public void Publish(string message)
    {
        Console.WriteLine("Publisher: Publishing message...");
        // 이벤트 발생
        OnNotify?.Invoke(message);
    }
}

public class Subscriber
{
    private string _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public void Subscribe(Publisher publisher)
    {
        // 이벤트에 델리게이트 메서드를 구독
        publisher.OnNotify += ReceiveMessage;
    }

    public void Unsubscribe(Publisher publisher)
    {
        // 이벤트 구독 해제
        publisher.OnNotify -= ReceiveMessage;
    }

    // 델리게이트 메서드
    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{_name} received: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber1 = new Subscriber("Subscriber 1");
        Subscriber subscriber2 = new Subscriber("Subscriber 2");

        // 구독자들이 퍼블리셔의 이벤트를 구독
        subscriber1.Subscribe(publisher);
        subscriber2.Subscribe(publisher);

        // 메시지 퍼블리싱
        publisher.Publish("Hello, world!");

        // 한 구독자가 구독 해제
        subscriber1.Unsubscribe(publisher);

        // 다시 메시지 퍼블리싱
        publisher.Publish("Goodbye, world!");

        // 프로그램 종료를 기다리기 위해 입력 대기
        Console.ReadLine();
    }
}

