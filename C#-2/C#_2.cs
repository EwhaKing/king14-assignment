using System;

namespace DelegateExample
{
    public delegate void Notify(string message);

    public class Publisher
    {
        public event Notify OnPublish;

        public void PublishMessage(string message)
        {
            OnPublish?.Invoke(message);
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
            publisher.OnPublish += DisplayMessage;
        }

        private void DisplayMessage(string message)
        {
            Console.WriteLine($"{_name} received message: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();

            Subscriber subscriber1 = new Subscriber("Subscriber 1");
            Subscriber subscriber2 = new Subscriber("Subscriber 2");

            subscriber1.Subscribe(publisher);
            subscriber2.Subscribe(publisher);

            publisher.PublishMessage("Hello, World!");

            Action<string> action = message => Console.WriteLine($"Action delegate received message: {message}");
            action("Hello from Action delegate!");

            Func<int, int, int> add = (x, y) => x + y;
            int result = add(5, 10);
            Console.WriteLine($"Func delegate result: {result}");
        }
    }
}
