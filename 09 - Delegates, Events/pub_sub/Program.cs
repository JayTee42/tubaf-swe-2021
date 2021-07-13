using System;

delegate void PublisherEventHandler(string msg);

class Publisher
{
    private static Random _rand = new Random();
    public event PublisherEventHandler MessageReceived;

    public void ReceiveMessage()
    {
        // ...
        var msg = $"Some message: { _rand.Next() }";

        // Notify the subscribers:
        /*
            Equivalent:
            if (MessageReceived != null)
            {
                MessageReceived(msg);
            }
        */

        MessageReceived?.Invoke(msg);
    }
}

class Subscriber1
{
    public void HandleMessage(string msg) => Console.WriteLine($"Subscriber 1 handles message: { msg }");
}

class Subscriber2
{
    public void HandleMessage(string msg) => Console.WriteLine($"Subscriber 2 handles message: { msg }");
}

class Program
{
    static void Main(string[] args)
    {
        var sub1a = new Subscriber1();
        var sub1b = new Subscriber1();
        var sub2 = new Subscriber2();

        var publisher = new Publisher();

        publisher.MessageReceived += sub1b.HandleMessage;
        publisher.MessageReceived += sub2.HandleMessage;
        publisher.MessageReceived -= sub1b.HandleMessage;

        publisher.ReceiveMessage();
    }
}
