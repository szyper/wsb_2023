using static _8_1_1_zdarzenia.Publisher;

namespace _8_1_1_zdarzenia
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

        public class Subscriber
        {
            public Subscriber (int threshold, string name)
            {
                this.Threshold = threshold;
                this.Name = name;
            }
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
                    Console.WriteLine("{0} nie otrzymał wiadomości: {1} o priorytecie: {2}", Name, message, priority);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber sub1 = new Subscriber(3, "Subskrybent 1");
            Subscriber sub2 = new Subscriber(4, "Subskrybent 2");

            pub.MessageEvent += sub1.OnMessageReceived;

            pub.SendMessage("Pierwsza wiadomość", 1);
            pub.MessageEvent += sub2.OnMessageReceived;

            pub.SendMessage("Druga wiadomość", 2);



            pub.SendMessage("Trzecia wiadomość", 3);
            pub.SendMessage("Czwarta wiadomość", 4);


        }
    }
}