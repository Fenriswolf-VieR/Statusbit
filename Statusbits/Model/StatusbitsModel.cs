using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Statusbits.Annotations;

namespace Statusbits.Model
{
  public class StatusbitsModel : INotifyPropertyChanged
  {

    private string _version;
    public string Version
    {
      get => _version;
      set { _version = value; OnPropertyChanged(nameof(Version)); }
    }

    private string _errorMsg = "";
    public string ErrorMsg
    {
      get => _errorMsg;
      set { _errorMsg = value; OnPropertyChanged(nameof(ErrorMsg)); }
    }

    private int _bit;
    public int Bit
    {
      get => _bit;
      set { _bit = value; OnPropertyChanged(nameof(Bit)); }
    }

    private string _calculationType;
    public string CalculationType
    {
      get => _calculationType;
      set { _calculationType = value; OnPropertyChanged(nameof(CalculationType)); }
    }

    private string _language;
    public string Language
    {
        get => _language;
        set { _language = value; OnPropertyChanged(nameof(Language)); }
    }

    private string _Language_Resources;
    public string Language_Resources
    {
      get => _Language_Resources;
      set { _Language_Resources = value; OnPropertyChanged(nameof(Language_Resources)); }
    }

    private string _COT_Resources;
    public string COT_Resources
    {
        get => _COT_Resources;
        set { _COT_Resources = value; OnPropertyChanged(nameof(COT_Resources)); }
    }

    private string _ScanClipboard_Resources;
    public string ScanClipboard_Resources
    {
        get => _ScanClipboard_Resources;
        set { _ScanClipboard_Resources = value; OnPropertyChanged(nameof(ScanClipboard_Resources)); }
    }

    private string _Version_Resources;
    public string Version_Resources
    {
        get => _Version_Resources;
        set { _Version_Resources = value; OnPropertyChanged(nameof(Version_Resources)); }
    }

    private int _cotValue;
    public int CotValue
    {
      get => _cotValue;
      set { _cotValue = value; OnPropertyChanged(nameof(CotValue)); }
    }

    private string _cotMessage;
    public string CotMessage
    {
      get => _cotMessage;
      set { _cotMessage = value; OnPropertyChanged(nameof(CotMessage)); }
    }

    private List<string> _cotMessages = new List<string>();
    public List<string> CotMessages
    {
      get => _cotMessages;
      set { _cotMessages = value; OnPropertyChanged(nameof(CotMessages)); }
    }

    private List<string> _statusBits = new List<string>();
    public List<string> StatusBits
    {
      get => _statusBits;
      set { _statusBits = value; OnPropertyChanged(nameof(StatusBits)); }
    }

    private List<string> _statusBits8 = new List<string>();
    public List<string> StatusBits8
    {
        get => _statusBits8;
        set { _statusBits8 = value; OnPropertyChanged(nameof(StatusBits8)); }
    }

    private List<string> _statusBits7 = new List<string>();
    public List<string> StatusBits7
    {
        get => _statusBits7;
        set { _statusBits7 = value; OnPropertyChanged(nameof(StatusBits7)); }
    }

    private List<string> _statusBits6 = new List<string>();
    public List<string> StatusBits6
    {
        get => _statusBits6;
        set { _statusBits6 = value; OnPropertyChanged(nameof(StatusBits6)); }
    }

    private List<string> _statusBits5 = new List<string>();
    public List<string> StatusBits5
    {
        get => _statusBits5;
        set { _statusBits5 = value; OnPropertyChanged(nameof(StatusBits5)); }
    }

    private List<string> _statusBits4 = new List<string>();
    public List<string> StatusBits4
    {
        get => _statusBits4;
        set { _statusBits4 = value; OnPropertyChanged(nameof(StatusBits4)); }
    }

    private List<string> _statusBits3 = new List<string>();
    public List<string> StatusBits3
    {
        get => _statusBits3;
        set { _statusBits3 = value; OnPropertyChanged(nameof(StatusBits3)); }
    }

    private List<string> _statusBits2 = new List<string>();
    public List<string> StatusBits2
    {
        get => _statusBits2;
        set { _statusBits2 = value; OnPropertyChanged(nameof(StatusBits2)); }
    }

    private List<string> _statusBits1 = new List<string>();
    public List<string> StatusBits1
    {
        get => _statusBits1;
        set { _statusBits1 = value; OnPropertyChanged(nameof(StatusBits1)); }
    }
     
    private List<string> _clipboardOptions = new List<string>();
    public List<string> ClipboardOptions
    {
      get => _clipboardOptions;
      set { _clipboardOptions = value; OnPropertyChanged(nameof(ClipboardOptions)); }
    }

    private List<string> _values = new List<string>();
    public List<string> Values
    {
      get => _values;
      set { _values = value; OnPropertyChanged(nameof(Values)); }
    }

    private IList<object> _items = new List<object>();
    public IList<object> Items
    {
      get => _items;
      set { _items = value; OnPropertyChanged(nameof(Items)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
