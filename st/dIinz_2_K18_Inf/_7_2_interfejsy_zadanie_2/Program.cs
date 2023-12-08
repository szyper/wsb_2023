namespace _7_2_interfejsy_zadanie_2
{
  public interface IRandomList
  {
    int Count { get; }
    void Display();
    List<int> DivisibleBy3Or5();
    List<int> Odd();
    List<int> Ascending();
    List<int> Descending();
    public event EmptyListHandler EmptyList;
  }

  delegate List<int> ListOperation(IRandomList list);
  public delegate void EmptyListHandler();

  class RandomList : IRandomList
  {
    private List<int> list;
    public int Count
    {
      get
      {
        return list.Count;
      }
    }

    public RandomList(int length, int min, int max)
    {
      list = new List<int>();
      Random rnd = new Random();
      for (int i = 0; i < length; i++)
      {
        list.Add(rnd.Next(min, max + 1));
      }

      if (list.Count == 0)
      {
        EmptyList?.Invoke();
      }
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