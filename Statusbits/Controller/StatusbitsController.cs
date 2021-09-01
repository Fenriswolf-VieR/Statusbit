
using System;
using System.Collections.Generic;
using System.Linq;
using Statusbits.Model;
using Windows.ApplicationModel.Resources;

namespace Statusbits.Controller
{
    class StatusbitsController
  {

    private ResourceLoader resource;
    public StatusbitsModel Model { get; set; }
    private BitDecryption.BitDecryption CalculateBits;

    private Dictionary<string, BitDecryption.BitDecryption.BaseType> baseTypeHelper;
    public StatusbitsController(int bits, string version="10.00")
    {
      CalculateBits = new BitDecryption.BitDecryption();
      Model = new StatusbitsModel();

      //Add Clipboard options
      Model.ClipboardOptions.Add("no");
      Model.ClipboardOptions.Add("Hexadecimal");
      Model.ClipboardOptions.Add("Decimal");
      Model.ClipboardOptions.Add("Binary");
      //Model.ClipboardOptions.Add("signed decimal");

      Model.Bit = bits;
      Model.Version = version;

      //set default value for decimal, signedDecimal, Hexadecimal, binary
      Model.Values.Add("0");
      Model.Values.Add("0");
      Model.Values.Add("0");
      Model.Values.Add("0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000");

      //Load bits from Version
      UpdateStatusbitsFromVersion(Model.Version);

      //Load COT Messages
      resource = new ResourceLoader("COT");
      for (var i = 0; i < Model.Bit; i++)
      {
        Model.CotMessages.Add(resource.GetString(i.ToString()));
      }
      Model.CotValue = 0;
      Model.CotMessage = Model.CotMessages[Model.CotValue];

      //create baseTypeHelper
      baseTypeHelper = new Dictionary<string, BitDecryption.BitDecryption.BaseType>();

      baseTypeHelper.Add("Decimal", BitDecryption.BitDecryption.BaseType.Decimal);
      //baseTypeHelper.Add("SignedDecimal", BitDecryption.BitDecryption.BaseType.SignedDecimal);
      baseTypeHelper.Add("Hexadecimal", BitDecryption.BitDecryption.BaseType.Hex);
      baseTypeHelper.Add("Binary", BitDecryption.BitDecryption.BaseType.Binary);

      SetLanguage("en");
    }

    //Calculate values from input and set checkboxes
    public void UpdateValues(string value, string baseForm, IList<object> items8, IList<object> items7, IList<object> items6, IList<object> items5, IList<object> items4, IList<object> items3, IList<object> items2, IList<object> items1)
    {
      Model.ErrorMsg = "";
      try
      {
        var Bit = BitDecryption.BitDecryption.Bitness.Bit64;
        if (Model.Bit == (int)BitDecryption.BitDecryption.Bitness.Bit32)
        {
          Bit = BitDecryption.BitDecryption.Bitness.Bit32;
        }
        Model.Values = CalculateBits.CalculateFromBase(value, Bit, baseTypeHelper[baseForm]);
        CalculateBits.CalculateActiveCheckboxes(Model.StatusBits, items8, items7, items6, items5, items4, items3, items2, items1, value, Bit, baseTypeHelper[baseForm]);

        if (Model.Bit == 64)
        {
          Model.CotValue = CalculateBits.CalculateCOT(Model.StatusBits, items1.Concat(items2).Concat(items3).Concat(items4).Concat(items5).Concat(items6).Concat(items7).Concat(items8).ToList());
          Model.CotMessage = Model.CotMessages[Model.CotValue];
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        Model.ErrorMsg = e.ToString();
      }
    }

    //Update Values from given Checkboxes
    public void UpdateFromCheckboxes(IList<object> items)
    {

      try
      {
        var Bit = BitDecryption.BitDecryption.Bitness.Bit64;
        if (Model.Bit == (int)BitDecryption.BitDecryption.Bitness.Bit32)
        {
          Bit = BitDecryption.BitDecryption.Bitness.Bit32;
        }

        Model.Items = items;
        Model.Values = CalculateBits.CalculateFromCheckBoxes(Model.Items, Model.StatusBits, Bit);
        if (Model.Bit == 64)
        {
          Model.CotValue = CalculateBits.CalculateCOT(Model.StatusBits, items);
          Model.CotMessage = Model.CotMessages[Model.CotValue];
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    public void UpdateStatusbitsFromVersion(string version)
    {
      try
      {
        Model.Version = version;
        resource = new ResourceLoader(Model.Version);

        List<string> newStatusbits = new List<string>();
        List<string> newStatusbits1 = new List<string>();
        List<string> newStatusbits2 = new List<string>();
        List<string> newStatusbits3 = new List<string>();
        List<string> newStatusbits4 = new List<string>();
        List<string> newStatusbits5 = new List<string>();
        List<string> newStatusbits6 = new List<string>();
        List<string> newStatusbits7 = new List<string>();
        List<string> newStatusbits8 = new List<string>();

        for (var i = 0; i < Model.Bit; i++)
        {
          newStatusbits.Add(i.ToString() + " " + resource.GetString(i.ToString()));
          switch (i / 8)
          {
            case (0):
                newStatusbits1.Add(i.ToString() + " " + resource.GetString(i.ToString()));
                break;

            case (1):
                newStatusbits2.Add(i.ToString() + " " + resource.GetString(i.ToString()));
                break;

            case (2):
                newStatusbits3.Add(i.ToString() + " " + resource.GetString(i.ToString()));
                break;

            case (3):
                newStatusbits4.Add(i.ToString() + " " + resource.GetString(i.ToString()));
                break;

            case (4):
                newStatusbits5.Add(i.ToString() + " " + resource.GetString(i.ToString()));
                break;

            case (5):
                newStatusbits6.Add(i.ToString() + " " + resource.GetString(i.ToString()));
                break;

            case (6):
                newStatusbits7.Add(i.ToString() + " " + resource.GetString(i.ToString()));
                break;

            case (7):
                newStatusbits8.Add(i.ToString() + " " + resource.GetString(i.ToString()));
                break;
          }
        }
        newStatusbits.Reverse();
        newStatusbits1.Reverse();
        newStatusbits2.Reverse();
        newStatusbits3.Reverse();
        newStatusbits4.Reverse();
        newStatusbits5.Reverse();
        newStatusbits6.Reverse();
        newStatusbits7.Reverse();
        newStatusbits8.Reverse();

        Model.StatusBits = newStatusbits;
        Model.StatusBits1 = newStatusbits1;
        Model.StatusBits2 = newStatusbits2;
        Model.StatusBits3 = newStatusbits3;
        Model.StatusBits4 = newStatusbits4;
        Model.StatusBits5 = newStatusbits5;
        Model.StatusBits6 = newStatusbits6;
        Model.StatusBits7 = newStatusbits7;
        Model.StatusBits8 = newStatusbits8;

    }
    catch (Exception e)
    {
    Console.WriteLine(e);
    Model.ErrorMsg = e.ToString();
    }
  }

    public void UpdateBits(int bits)
    {
      try
      {
        Model.Bit = bits;
        UpdateStatusbitsFromVersion(Model.Version);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    public void SetLanguage(string language)
    {
        Model.Language = language;
        resource = new ResourceLoader("Resources_"+language);
        Model.COT_Resources = resource.GetString("CauseOfTransmission");
        Model.Language_Resources = resource.GetString("Language");
        Model.ScanClipboard_Resources = resource.GetString("ScanFromClipboard");
        Model.Version_Resources = resource.GetString("Version");
    }
  }
}
