namespace _6_2_project_dziedziczenie_ex_wyklad_muzyka
{
    abstract class Song
    {
        protected string title;
        protected string artist;
        protected string sound;

        public Song(string title, string artist, string sound)
        {
            this.title = title;
            this.artist = artist;
            this.sound = sound;
        }

        public abstract void Play();
    }

    class Rock : Song
    {
        protected string guitar;

        public Rock(string title, string artist, string guitar) : base(title, artist, "bębny")
        {
            this.guitar = guitar;
        }

        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {guitar}");
        }
    }

    class Pop : Song
    {
        private string synth;

        public Pop(string title, string artist, string synth) : base(title, artist, "vocals") 
        {
            this.synth = synth;
        }

        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {synth}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}