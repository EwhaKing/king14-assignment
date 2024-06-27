using System;

public class Publisher
{
    public event Action<string> OnPublish;


    public void Publish(string message)
    {
        Console.WriteLine("Publishing message: " + message);
        OnPublish?.Invoke(message); 
    }
}


public class Subscriber
{
 
    public void Subscribe(Publisher publisher)
    {
        
        publisher.OnPublish += HandlePublish;
    }

    private void HandlePublish(string message)
    {
        Console.WriteLine("Received message: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();


        subscriber.Subscribe(publisher);


        publisher.Publish("Hello, world!");
    }
}
