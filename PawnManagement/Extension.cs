

namespace PawnManagement
{
  internal static class Extension
  {
    public static int ToInt(this string str)
    {
      int result;
      int.TryParse(str, out result);
      return result;
    }
  }
}
