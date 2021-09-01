using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BitDecryption
{
    public class BitDecryption
  {
    private string binary;
    private string hex;
    private string signedDec;
    private string dec;

    public enum BaseType
    {
      Decimal = 10,
      Binary = 2,
      Hex = 16,
      SignedDecimal = 10
    }

    public enum Bitness
    {
      Bit64 = 64,
      Bit32 = 32
    }

    private void ValidateValue(string value, BaseType baseType)
    {
      if (!Regex.IsMatch(value, "^[01]+$") && baseType == BaseType.Binary)
      {
        throw new Exception("The system ran into an error. The given input can't be parsed to a binary number. Check for invalid characters.");
      }
      else if (!Regex.IsMatch(value, "^[0-9A-Fa-f]+$") && baseType == BaseType.Hex)
      {
        throw new Exception("The system ran into an error. The given input can't be parsed to a hexadecimal number. Check for invalid characters.");
      }
      else if (!Regex.IsMatch(value, "^[-0-9]+$") && baseType == BaseType.Decimal)
      {
        throw new Exception("The system ran into an error. The given input can't be parsed to a decimal number. Check for invalid characters.");
      }
    }

    //Calculate Values 
    public List<string> CalculateFromBase(string value, Bitness bit, BaseType baseType)
    {
      if (string.IsNullOrEmpty(value))
      {
        value = "0";
      }

      value = value.Replace(" ", "");
      ValidateValue(value, baseType);

      UInt64 unsignedDecValue;

      //check if value is negative for conversion to uint64
      try
      {
        if (Convert.ToInt64(value, (int)baseType) < 0)
        {
          Int64 temp = Convert.ToInt64(value, (int)baseType);
          value = Convert.ToString(temp, 2);
          baseType = BaseType.Binary;
        }
      }
      catch { }

      unsignedDecValue = Convert.ToUInt64(value, (int)baseType);

      switch (bit)
      {
        case Bitness.Bit32:
          dec = Convert.ToString(unsignedDecValue & 0xffffffff);
          hex = Convert.ToString((long)unsignedDecValue & 0xffffffff, 16);
          binary = Convert.ToString((long)unsignedDecValue & 0xffffffff, 2).PadLeft(32, '0');
                    break;
        case Bitness.Bit64:
          dec = Convert.ToString(unsignedDecValue);
          hex = Convert.ToString((long)unsignedDecValue, 16);
          binary = Convert.ToString((long)unsignedDecValue, 2).PadLeft(64, '0');
                    break;
      }
      List<string> values = new List<string>() { dec, signedDec, hex, binary };
      return FormatString(values);
    }

    //Update all Values from selected Checkboxes
    public List<string> CalculateFromCheckBoxes(IList<object> items, List<string> allStatusbits, Bitness bit)
    {
      IEnumerator item = items.GetEnumerator();

      Int64 decimalNumber = 0;
      int index;
      string currentItem;

      for (int i = 0; i < items.Count; i++)
      {
        item.MoveNext();
        currentItem = item.Current.ToString();
        index = (int)bit - 1 - allStatusbits.IndexOf(currentItem);
        decimalNumber += (Int64)Math.Pow(2, index);
      }

      List<string> values = new List<string>();
      values = CalculateFromBase(decimalNumber.ToString(), bit, BaseType.Decimal);
      return values;
    }

    public IList<object> CalculateActiveCheckboxes(List<string> allStatusBits, IList<object> items8, IList<object> items7, IList<object> items6, IList<object> items5, IList<object> items4, IList<object> items3, IList<object> items2, IList<object> items1, string number, Bitness bit, BaseType baseType)
    {
          for (int i = items8.Count - 1; i >= 0; i--)
          {
            items8.RemoveAt(i);
          }

        for (int i = items7.Count - 1; i >= 0; i--)
        {
            items7.RemoveAt(i);
        }

        for (int i = items6.Count - 1; i >= 0; i--)
        {
            items6.RemoveAt(i);
        }

        for (int i = items5.Count - 1; i >= 0; i--)
        {
            items5.RemoveAt(i);
        }

        for (int i = items4.Count - 1; i >= 0; i--)
        {
            items4.RemoveAt(i);
        }

        for (int i = items3.Count - 1; i >= 0; i--)
        {
            items3.RemoveAt(i);
        }

        for (int i = items2.Count - 1; i >= 0; i--)
        {
            items2.RemoveAt(i);
        }

        for (int i = items1.Count - 1; i >= 0; i--)
        {
            items1.RemoveAt(i);
        }

        if (string.IsNullOrEmpty(number))
      {
        number = "0";
      }

      //replace spaces from formatting
      number = number.Replace(" ", "");

      UInt64 unsignedDecValue;

      unsignedDecValue = Convert.ToUInt64(number, (int)baseType);

      int index = 0;

      while (unsignedDecValue > 0)
      {
        if (unsignedDecValue % 2 == 1)
        {
            switch (index / 8)
            {
                case (0):
                    items1.Add(allStatusBits[(int)bit - 1 - index]);
                    break;

                case (1):
                    items2.Add(allStatusBits[(int)bit - 1 - index]);
                    break;

                case (2):
                    items3.Add(allStatusBits[(int)bit - 1 - index]);
                    break;

                case (3):
                    items4.Add(allStatusBits[(int)bit - 1 - index]);
                    break;

                case (4):
                    items5.Add(allStatusBits[(int)bit - 1 - index]);
                    break;

                case (5):
                    items6.Add(allStatusBits[(int)bit - 1 - index]);
                    break;

                case (6):
                    items7.Add(allStatusBits[(int)bit - 1 - index]);
                    break;

                case (7):
                    items8.Add(allStatusBits[(int)bit - 1 - index]);
                    break;
            }
        }

        index++;
        unsignedDecValue /= 2;
      }
      return items1.Concat(items2).Concat(items3).Concat(items4).Concat(items5).Concat(items6).Concat(items7).Concat(items8).ToList();
    }
    public int CalculateCOT(List<string> allStatusBits, IList<object> items)
    {
      List<string> cot = new List<string>();
      allStatusBits.Reverse();
      cot = allStatusBits.GetRange(32, 6);
      allStatusBits.Reverse();
      int value = 0;

      for (int i = 0; i < cot.Count; i++)
      {
        if (items.Contains(cot[i]))
        {
          value += (int)Math.Pow(2, i);
        }
      }

      return value;
    }

    private List<string> FormatString(List<string> values)
    {
      int spacesBinary = 0;
      int spacesDecimal = 0;
      int spacesHexadecimal = 0;

      for (int i = 1; i < values[3].Length; i++)
      {
        //binary => space every 4 digits: 0000 0000 0000
        if (i % 4 == 0 && i < binary.Length)
        {
          values[3] = values[3].Insert(values[3].Length - (i + spacesBinary), " ");
          spacesBinary += 1;
        }
        //decimal => space every 3 digits: 100 000 000
        if (i % 3 == 0 && i < dec.Length)
        {
          values[0] = values[0].Insert(values[0].Length - (i + spacesDecimal), " ");
          spacesDecimal++;
        }
        //hex => space every 2 digits: FF FF FF
        if (i % 2 == 0 && i < hex.Length)
        {
          values[2] = values[2].Insert(values[2].Length - (i + spacesHexadecimal), " ");
          spacesHexadecimal++;
        }
      }

      return values;
    }
  }
}
