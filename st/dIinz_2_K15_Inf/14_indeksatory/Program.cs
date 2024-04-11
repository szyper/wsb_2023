using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_indeksatory
{
  internal class Program
  {
    class Dictionary
    {
      private string[,] data;
      public Dictionary()
      {
        data = new string[100, 2];
      }

      public int GetLength()
      {
        return data.Length;
      }

      public string this[string key]
      {
        get
        {
          for (int i = 0; i < data.GetLength(0); i++)
          {
            if (data[i, 0] == key)
            {
              return data[i, 1];
            }
          }
          throw new KeyNotFoundException();
        }

        set
        {
          for (int i = 0; i < data.GetLength(0); i++)
          {
            if (data[i, 0] == key)
            {
              data[i, 1] = value;
              return;
            }
            if (data[i, 0] == null)
            {
              data[i, 0] = key;
              data[i, 1] = value;
              return;
            }
          }
          throw new IndexOutOfRangeException();
        }
      }
    }
    static void Main(string[] args)
    {
      Dictionary dict = new Dictionary();
      Console.WriteLine(dict.GetLength()); //200

      dict["apple"] = "jabłko";
      dict["banana"] = "banan";
      Console.WriteLine(dict["banana"]); //banan

      Console.WriteLine(dict["test"]);

      Console.ReadKey();
    }
  }
}
