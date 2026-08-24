
using System.Linq;

namespace PawnManagement.Classes
{
  internal class StringFunctionsClass
  {
    public static string appendZeroes(string str)
    {
      if (str.Contains<char>('.'))
      {
        int num = str.IndexOf('.');
        if (str.Length - num == 1)
          str += "000";
        if (str.Length - num == 2)
          str += "00";
        if (str.Length - num == 3)
          str += "0";
      }
      else
        str += ".000";
      return str;
    }
  }
}
