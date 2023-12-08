using System.Security.Cryptography.X509Certificates;

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

    class Jazz : Song
    {
        protected string Sax { get; set; }

        public Jazz(string sax, string title, string artist, string sound) : base(title, artist, "vocals")
        {
            this.Sax = sax;
        }

        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {Sax}");
        }
    }

    class Rap : Song
    {
        protected string Beat { get; set; }

        public Rap(string beat, string title, string artist, string sound) : base(title, artist, "vocals")
        {
            this.Beat = beat;
        }

        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {Beat}");
        }
    }

    class HeavyMetal : Song
    {
        protected string Bass { get; set; }

        public HeavyMetal(string bass, string title, string artist, string sound) : base(title, artist, "vocals")
        {
            this.Bass = bass;
        }

        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {Bass}");
        }
    }

    class Player
    {
        public Dictionary<int, Song> PlayList { get; }

        public Player()
        {
            PlayList = new Dictionary<int, Song>();
        }
        public void AddSong(Song song)
        {
            var songCount = PlayList.Count;
            PlayList.Add(songCount+1, song);
        }
        public void RemoveSong(int songNumber)
        {
            PlayList.Remove(songNumber);
        }

        public void Play(int songNumber)
        {
            var song = PlayList.FirstOrDefault(s => s.Key == songNumber);
            if (song.Value != null)
            {
                this.PlayList[songNumber].Play();
                this.PlayList.Remove(songNumber);
            }
        }

        public void Play()
        {
            foreach (var song in PlayList)
            {
                song.Value.Play();
                RemoveSong(song.Key);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var isTrue = true;
            var player = new Player();
            while (isTrue)
            {
                Console.WriteLine("Odtwarzacz muzyki");
                Console.WriteLine("1. Dodaj utwór z gatunków Rock/Pop/Rap/HeavyMetal");
                Console.WriteLine("2. Włącz całą playliste");
                Console.WriteLine("3. Włącz wybrany utwór");
                var option = Console.ReadLine();
                switch(option)
                {
                    case "1":
                        AddSongToPlaylist(player);
                        break;
                    case "2":
                        player.Play();
                        break;
                    case "3":
                        foreach (var item in player.PlayList)
                        {
                            Console.WriteLine($"{item.Key} {item.Value}");
                        }
                        var songNumber = int.Parse(Console.ReadLine());
                        player.Play(songNumber);
                        break;
                    case "4":
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Błędny numer opcji");
                        break;
                }
            }
        }

        public static void AddSongToPlaylist(Player player)
        {
            var isTrue = true;
            while (isTrue)
            {
                Console.Write("Podaj tytuł:");
                var title = Console.ReadLine();
                Console.Write("Podaj autora:");
                var author = Console.ReadLine();
                Console.Write("Podaj gatunek (Rock/Pop/Rap/HeavyMetal):");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "Rock":
                        var song = new Rock("Test rock tytuł", "Janusz Kowalski", "dźwięk gitary");
                        player.AddSong(song);
                        break;
                    case "Pop":
                        var popSong = new Pop("Test rap tytuł", "Janusz Kowalski", "dźwięk syntezatora");
                        player.AddSong(popSong);
                        break;
                    case "Rap":
                        var rapSong = new Rap("beat test", "Test rock tytuł", "Janusz Kowalski", "dźwięk rapu");
                        player.AddSong(rapSong);
                        break;
                    case "HeavyMetal":
                        var heavyMetalSong = new HeavyMetal("dźwięk haevymetal test", "Test rap tytuł", "Janusz Kowalski", "dźwięk syntezatora");
                        player.AddSong(heavyMetalSong);
                        break;
                    default:
                        Console.WriteLine("Obecnie nie można użyć tego gatunku, użyj któregoś z Rock/Pop/Rap/HeavyMetal");
                        break;
                }

                Console.WriteLine("Czy chcesz dodać kolejny utwór? (T/N)");
                var declaration = Console.ReadLine();
                switch(declaration)
                {
                    case "T":
                        break;
                    case "N":
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Spróbuj jeszcze raz");
                        break;
                }
            }
        }
    }
}