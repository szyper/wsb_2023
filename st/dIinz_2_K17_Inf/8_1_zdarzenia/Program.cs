namespace _8_1_zdarzenia
{
    public delegate void MessageHandler(string message);
    public class Publisher
    {
        private int counter;
        public Publisher()
        {
            counter = 0;
        }

        public event MessageHandler MessageEvent;

        public void SendMessage(string message)
        {
            if (MessageEvent != null)
            {
                MessageEvent(message);
            }
        }
    }

    public class Subscriber
    {
        public void OnMessageReceived(string  message)
        {
            Console.WriteLine("Otrzymałem wiadomość: {0}", message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();

            pub.SendMessage("Pierwsza wiadomość");
            pub.MessageEvent += sub.OnMessageReceived;
            pub.SendMessage("Druga wiadomość");
            pub.SendMessage("Trzecia wiadomość");
            pub.MessageEvent -= sub.OnMessageReceived;
            pub.SendMessage("Czwarta wiadomość");
            pub.MessageEvent += sub.OnMessageReceived;
            pub.SendMessage("Piąta wiadomość");


        }
    }
}