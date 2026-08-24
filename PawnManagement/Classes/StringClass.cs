
namespace PawnManagement.Classes
{
  internal class StringClass
  {
    public static string appendZeroes(string Range)
    {
      string str = "";
      int length = Range.Length;
      for (int index = 0; index < length - 1; ++index)
        str += "0";
      return str;
    }

    public static string appendZeroesBasedOnLength(string Length)
    {
      string str = "";
      int num = int.Parse(Length);
      for (int index = 0; index < num; ++index)
        str += "0";
      return str;
    }
  }
}
