namespace _8_1_zdarzenia
{
    public delegate void MessageHandler(string message, int priority);

    public class Publisher
    {
        public event MessageHandler MessageEvent;

        public void SendMessage(string message, int priority)
        {
            if (MessageEvent != null)
            {
                MessageEvent(message, priority);
            }
        }
    }

    public class Subscriber
    {
        public int Threshold { get; set; }
        public string Name { get; set; }
        public void OnMessageReceived(string message, int priority)
        {
            if (priority <= Threshold)
            {
                Console.WriteLine("{0} otrzymał wiadomość: {1} o priorytecie: {2}", Name, message, priority);
            }
            else
            {
                Console.WriteLine("{0} nie otrzymał wiadomości {1} o priorytecie: {2}, ponieważ jest zbyt wysoki dla jego progu", Name, message, priority);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber sub1 = new Subscriber();
            Subscriber sub2 = new Subscriber();

            sub1.Threshold = 3;
            sub2.Threshold = 4;

            sub1.Name = "Subskrybent 1";
            sub2.Name = "Subskrybent 2";

            pub.MessageEvent += sub1.OnMessageReceived;
            pub.MessageEvent += sub2.OnMessageReceived;

            pub.SendMessage("Pierwsza wiadomość", 1);
            pub.SendMessage("Druga wiadomość", 2);
            pub.SendMessage("Trzecia wiadomość", 3);
            pub.SendMessage("Czwarta wiadomość", 4);
            pub.SendMessage("Piąta wiadomość", 5);
        }
    }
}