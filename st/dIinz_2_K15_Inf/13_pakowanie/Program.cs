using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_pakowanie
{
  internal class Program
  {
    class BoxingUnboxing
    {
      public object Boxing(int value)
      {
        return value;
      }

      public int Unboxing(object obj)
      {
        return (int)obj;
      }

      public byte[] Pack(int[] values)
      {
        byte[] packedValues = new byte[values.Length * sizeof(int)];
        Buffer.BlockCopy(values, 0, packedValues, 0, values.Length);
        return packedValues;
      }

      public int[] Unpack(byte[] packedValues)
      {
        int[] values = new int[packedValues.Length / sizeof(int)];
        Buffer.BlockCopy(packedValues, 0, values, 0, packedValues.Length);
        return values;
      }
    }
    static void Main(string[] args)
    {
      BoxingUnboxing boxingUnboxing = new BoxingUnboxing();

      object boxedValue = boxingUnboxing.Boxing(42);
      int unboxedValue = boxingUnboxing.Unboxing(boxedValue);
      Console.WriteLine($"unboxedValue: {unboxedValue}");

      int[] values = new int[] { 1, 2, 3, 4, 5 };
      byte[] packedValues = boxingUnboxing.Pack(values);
      Console.WriteLine($"packedValues: {BitConverter.ToString(packedValues)}");

      int[] unpackedValues = boxingUnboxing.Unpack(packedValues);
      Console.WriteLine($"unpackedValues: {string.Join(", ", unpackedValues)}");

      Console.ReadKey();
    }
  }
}
