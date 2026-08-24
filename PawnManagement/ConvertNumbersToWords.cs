

using System;
using System.Collections.Generic;
using System.Linq;

namespace PawnManagement
{
  internal class ConvertNumbersToWords
  {
    private static List<string> oneTo19Text = new List<string>()
    {
      "Zero",
      "One",
      "Two",
      "Three",
      "Four",
      "Five",
      "Six",
      "Seven",
      "Eight",
      "Nine",
      "Ten",
      "Eleven",
      "Twelve",
      "Thirteen",
      "Fourteen",
      "Fifteen",
      "Sixteen",
      "Seventeen",
      "Eighteen",
      "Nineteen"
    };
    private static Dictionary<int, string> tensDigit = new Dictionary<int, string>()
    {
      {
        2,
        "Twenty"
      },
      {
        3,
        "Thirty"
      },
      {
        4,
        "Fourty"
      },
      {
        5,
        "Fifty"
      },
      {
        6,
        "Sixty"
      },
      {
        7,
        "Seventy"
      },
      {
        8,
        "Eighty"
      },
      {
        9,
        "NineTy"
      }
    };
    private static Dictionary<int, string> HundredDigit = new Dictionary<int, string>()
    {
      {
        3,
        "Hundred"
      },
      {
        4,
        "Thousand"
      },
      {
        6,
        "Lakhs"
      },
      {
        8,
        "Crore"
      }
    };

    public static string ConvertNumberAsText(int num)
    {
      int length = num.ToString().Length;
      string str1 = num.ToString();
      int position = length;
      if (length == 1)
        return ConvertNumbersToWords.oneTo19Text[num];
      string str2 = string.Empty;
      for (int startIndex = 0; startIndex < length; ++startIndex)
      {
        if (ConvertNumbersToWords.HundredDigit.Where<KeyValuePair<int, string>>((Func<KeyValuePair<int, string>, bool>) (p => p.Key == position)).ToDictionary<KeyValuePair<int, string>, int, string>((Func<KeyValuePair<int, string>, int>) (p => p.Key), (Func<KeyValuePair<int, string>, string>) (p => p.Value)).Count == 0)
        {
          int key = str1.Substring(startIndex, 1).ToInt();
          int index;
          if (key < 2)
          {
            index = str1.Substring(startIndex, 2).ToInt();
            ++startIndex;
            position--;
          }
          else
          {
            str2 = str2 + " " + ConvertNumbersToWords.tensDigit[key];
            ++startIndex;
            position--;
            index = str1.Substring(startIndex, 1).ToInt();
          }
          str2 = str2 + " " + ConvertNumbersToWords.oneTo19Text[index];
          if (position > 2)
            str2 = str2 + " " + ConvertNumbersToWords.HundredDigit[position];
        }
        else
        {
          int index = str1.Substring(startIndex, 1).ToInt();
          str2 = str2 + " " + ConvertNumbersToWords.oneTo19Text[index];
          if (position > 2)
            str2 = str2 + " " + ConvertNumbersToWords.HundredDigit[position];
        }
        position--;
      }
      return str2;
    }

    public static string NumberToWords(int number)
    {
      if (number == 0)
        return "Zero";
      if (number < 0)
        return "minus " + ConvertNumbersToWords.NumberToWords(Math.Abs(number));
      string words = "";
      if (number / 10000000 > 0)
      {
        words = words + ConvertNumbersToWords.NumberToWords(number / 10000000) + " Crore ";
        number %= 10000000;
      }
      if (number / 100000 > 0)
      {
        words = words + ConvertNumbersToWords.NumberToWords(number / 100000) + " Lakhs ";
        number %= 100000;
      }
      if (number / 1000 > 0)
      {
        words = words + ConvertNumbersToWords.NumberToWords(number / 1000) + " Thousand ";
        number %= 1000;
      }
      if (number / 100 > 0)
      {
        words = words + ConvertNumbersToWords.NumberToWords(number / 100) + " Hundred ";
        number %= 100;
      }
      if (number > 0)
      {
        if (words != "")
          words += "and ";
        string[] strArray1 = new string[20]
        {
          "Zero",
          "One",
          "Two",
          "Three",
          "Four",
          "Five",
          "Six",
          "Seven",
          "Eight",
          "Nine",
          "Ten",
          "Eleven",
          "Twelve",
          "Thirteen",
          "Fourteen",
          "Fifteen",
          "Sixteen",
          "Seventeen",
          "Eighteen",
          "Nineteen"
        };
        string[] strArray2 = new string[10]
        {
          "Zero",
          "Ten",
          "Twenty",
          "Thirty",
          "Forty",
          "Fifty",
          "Sixty",
          "Seventy",
          "Eighty",
          "Ninety"
        };
        if (number < 20)
        {
          words += strArray1[number];
        }
        else
        {
          words += strArray2[number / 10];
          if (number % 10 > 0)
            words = words + "-" + strArray1[number % 10];
        }
      }
      return words;
    }
  }
}
