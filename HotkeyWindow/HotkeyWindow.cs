using System;
using System.Diagnostics;
using System.Windows.Forms;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.Storage;
using WK.Libraries.SharpClipboardNS;

namespace HotkeyWindow
{
    class HotkeyAppContext : ApplicationContext
    {
        private Process process = null;
        private SharpClipboard clipboard = new SharpClipboard();

        public HotkeyAppContext()
        {
            int processId = (int)ApplicationData.Current.LocalSettings.Values["processId"];
            process = Process.GetProcessById(processId);
            process.EnableRaisingEvents = true;
            process.Exited += HotkeyAppContext_Exited;
            clipboard.ClipboardChanged += ClipboardChanged;
        }

        private void HotkeyAppContext_Exited(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Connection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
            Debug.WriteLine("Connection_ServiceClosed");
        }

        private void ClipboardChanged(Object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            // Is the content copied of text type?
            if (e.ContentType == SharpClipboard.ContentTypes.Text)
            {
                // bring the UWP to the foreground (optional)
                /* IEnumerable<AppListEntry> appListEntries = await Package.Current.GetAppListEntriesAsync();
                await appListEntries.First().LaunchAsync();*/

                // Get the cut/copied text.
                Debug.WriteLine(clipboard.ClipboardText);
                string id = clipboard.ClipboardText;
                Send_to_Statusbits(id);
            }

        }

        private async void Send_to_Statusbits(string ID)
        {
            ValueSet hotkeyPressed = new ValueSet();
            hotkeyPressed.Add("ID", ID);

            AppServiceConnection connection = new AppServiceConnection();
            connection.PackageFamilyName = Package.Current.Id.FamilyName;
            connection.AppServiceName = "HotkeyConnection";
            AppServiceConnectionStatus status = await connection.OpenAsync();
            if (status != AppServiceConnectionStatus.Success)
            {
                Debug.WriteLine(status);
                Application.Exit();
            }
            connection.ServiceClosed += Connection_ServiceClosed;
            AppServiceResponse response = await connection.SendMessageAsync(hotkeyPressed);
        }
    }
}