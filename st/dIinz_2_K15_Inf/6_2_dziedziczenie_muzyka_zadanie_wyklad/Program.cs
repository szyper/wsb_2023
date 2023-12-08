namespace _6_3_dziedziczenie_muzyka_zadanie_wyklad
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
    public Rock(string title, string artist, string sound, string guitar) : base(title, artist, "bębny")
    {
      this.guitar = guitar;
    }

    public override void Play()
    {
      Console.WriteLine($"Odtwarzanie {title} przez {artist}");
      Console.WriteLine($"Dźwięk: {sound}, {guitar}");
    }
  }

  class Pop : Song
  {
    private string synth;
    public Pop(string title, string artist, string sound, string synth) : base(title, artist, "śpiew")
    {
      this.synth = synth;
    }

    public override void Play()
    {
      Console.WriteLine($"Odtwarzanie {title} przez {artist}");
      Console.WriteLine($"Dźwięk: {sound}, {synth}");
    }
  }

  class Jazz : Song
  {
    private string saxophone;
    public Jazz(string title, string artist, string sound, string saxophone) : base(title, artist, "fortepian")
    {
      this.saxophone = saxophone;
    }

    public override void Play()
    {
      Console.WriteLine($"Odtwarzanie {title} przez {artist}");
      Console.WriteLine($"Dźwięk: {sound}, {saxophone}");
    }
  }

  class Rap : Song
  {
    private string beat;
    public Rap(string title, string artist, string sound, string saxophone) : base(title, artist, "fortepian")
    {
      this.beat = saxophone;
    }

    public override void Play()
    {
      Console.WriteLine($"Odtwarzanie {title} przez {artist}");
      Console.WriteLine($"Dźwięk: {sound}, {beat}");
    }
  }

  class Metal : Song
  {
    private string distortion;
    public Metal(string title, string artist, string sound, string distortion) : base(title, artist, sound)
    {
      this.distortion = distortion;
    }

    public override void Play()
    {
      Console.WriteLine($"Odtwarzanie {title} przez {artist}");
      Console.WriteLine($"Dźwięk: {sound}, {distortion}");
    }
  }

  class Player
  {
    private List<Song> playlist;
    public Player()
    {
      playlist = new List<Song>();
    }

    public void Add(Song song)
    {
      playlist.Add(song);
    }

    public void Remove(int songNumber)
    {
      playlist.RemoveAt(songNumber);
    }

    public void Play(int songNumber)
    {
      playlist[songNumber].Play();
    }
    public int Count()
    {
      return playlist.Count();
    }
  }
  internal class Program
  {
    static Song CreateSong(string genre, string title, string sound, string artist)
    {
      Song song = null;

      switch (genre)
      {
        case "rock":
          Console.Write("Podaj brzmienie gitary:");
          string? guitar = Console.ReadLine();
          song = new Rock(title, artist, sound, guitar);
          break;
        case "pop":
          Console.Write("Podaj brzmienie syntezy:");
          string? synth = Console.ReadLine();
          song = new Rock(title, artist, sound, synth);
          break;
        case "jazz":
          Console.Write("Podaj brzmienie saksofonu:");
          string? saxophone = Console.ReadLine();
          song = new Rock(title, artist, sound, saxophone);
          break;
        case "rap":
          Console.Write("Podaj brzmienie beatu:");
          string? beat = Console.ReadLine();
          song = new Rock(title, artist, sound, beat);
          break;
        case "metal":
          Console.Write("Podaj zniekształcenie dźwięku:");
          string? distortion = Console.ReadLine();
          song = new Rock(title, artist, sound, distortion);
          break;
      }
      return song;
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Hello, World!");
    }
  }
}