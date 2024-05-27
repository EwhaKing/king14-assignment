using System;

namespace DelegateExample
{
    // 발행자 클래스
    public class Publisher
    {
        // Action 델리게이트를 사용한 이벤트 정의
        public event Action<string>? OnPublish;

        // 이벤트를 발생시키는 메서드
        public void PublishData(string data)
        {
            OnPublish?.Invoke(data);
        }
    }

    // 구독자 클래스
    public class Subscriber
    {
        private string name;

        public Subscriber(string name, Publisher publisher)
        {
            this.name = name;
            // Publisher의 이벤트에 메서드를 구독
            publisher.OnPublish += HandleEvent;
        }

        // 이벤트 핸들러 메서드
        private void HandleEvent(string data)
        {
            Console.WriteLine($"{name} received: {data}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber1 = new Subscriber("Subscriber 1", publisher);
            Subscriber subscriber2 = new Subscriber("Subscriber 2", publisher);

            publisher.PublishData("Hello, World!");
        }
    }
}
