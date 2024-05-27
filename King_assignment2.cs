using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    // 델리게이트 선언
    public delegate void NotifyEventHandler(string message);

    // 이벤트를 발생 클래스
    public class Publisher
    {
        public event NotifyEventHandler NotifyEvent;

        public void RaiseEvent(string message)
        {
            if (NotifyEvent != null)
            {
                NotifyEvent(message);
            }
        }
    }

    // 이벤트를 구독 클래스
    public class Subscriber
    {
        private string _name;

        public Subscriber(string name, Publisher publisher)
        {
            _name = name;
            publisher.NotifyEvent += OnNotifyEvent;
        }

        private void OnNotifyEvent(string message)
        {
            Console.WriteLine($"{_name} message: {message}");
        }
    }

    class King_assignment2
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();

            Subscriber subscriber1 = new Subscriber("Subscriber 1", publisher);
            Subscriber subscriber2 = new Subscriber("Subscriber 2", publisher);

            publisher.RaiseEvent("Hello");

        }
    }
}
