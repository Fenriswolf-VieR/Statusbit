using System;
using System.Diagnostics;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Statusbits.Controller;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Storage;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.Resources;

namespace Statusbits
{
    public sealed partial class MainPage : Page
  {
    private StatusbitsController controller;
    private ResourceLoader resource;
    private bool allowed_to_recieve = false;

    public MainPage(){
      try
      {
        controller = new StatusbitsController(64);
        this.DataContext = controller;

        this.InitializeComponent();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    private void ClipboardType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      allowed_to_recieve = false;
      if (ClipboardType.SelectedItem.ToString() != "no")
      {
        allowed_to_recieve = true;
      }
    }

    private void DecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == VirtualKey.Enter)
      {
        controller.UpdateValues(DecimalTB.Text, "Decimal", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
                 
      }
    }

    private void SignedDecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == VirtualKey.Enter)
      {
        controller.UpdateValues(SignedDecimalTB.Text, "SignedDecimal", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
                 
      }
    }

    private void HexadecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == VirtualKey.Enter)
      {
        controller.UpdateValues(HexadecimalTB.Text, "Hexadecimal", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
                 
      }
    }

    private void BinaryTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == VirtualKey.Enter)
      {
        controller.UpdateValues(BinaryTB.Text, "Binary", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
                 
      }
    }

    private void ActiveBits_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        IList<object> new_checkboxes = ActiveBits1.SelectedItems.Concat(ActiveBits2.SelectedItems).Concat(ActiveBits3.SelectedItems).Concat(ActiveBits4.SelectedItems).Concat(ActiveBits5.SelectedItems).Concat(ActiveBits6.SelectedItems).Concat(ActiveBits7.SelectedItems).Concat(ActiveBits8.SelectedItems).ToList();
        controller.UpdateFromCheckboxes(new_checkboxes);
    }

    private void Bit64_OnChecked(object sender, RoutedEventArgs e)
    {
        if(BinaryTB != null)
        {
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateBits(64);
            controller.UpdateValues(value, "Binary", items8,items7,items6,items5,items4,items3,items2,items1);
                 
        }
        else
        {
            controller.UpdateBits(64);
        }
    }
    private void Bit32_OnChecked(object sender, RoutedEventArgs e)
    {
        string value = BinaryTB.Text.Substring(40);
        IList<object> items1 = ActiveBits1.SelectedItems;
        IList<object> items2 = ActiveBits2.SelectedItems;
        IList<object> items3 = ActiveBits3.SelectedItems;
        IList<object> items4 = ActiveBits4.SelectedItems;
        IList<object> items5 = ActiveBits5.SelectedItems;
        IList<object> items6 = ActiveBits6.SelectedItems;
        IList<object> items7 = ActiveBits7.SelectedItems;
        IList<object> items8 = ActiveBits8.SelectedItems;
        controller.UpdateBits(32);
        controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
             
        }

    private void DecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(DecimalTB.Text, "Decimal", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
             
    }

    private void SignedDecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(SignedDecimalTB.Text, "SignedDecimal", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
             
    }

    private void HexadecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(HexadecimalTB.Text, "Hexadecimal", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
             
    }

    private void BinaryTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(BinaryTB.Text, "Binary", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
             
    }

    private void V1000_OnClick(object sender, RoutedEventArgs e)
    {
        if (controller.Model.Version != "10.00")
        {
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateStatusbitsFromVersion("10.00");
            controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
        }  
    }
    private void V820_OnClick(object sender, RoutedEventArgs e)
    {
        if (controller.Model.Version != "8.20")
        {
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateStatusbitsFromVersion("8.20");
            controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
        }
    }   

    private void V810_OnClick(object sender, RoutedEventArgs e)
    {
        if (controller.Model.Version != "8.10")
        {
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateStatusbitsFromVersion("8.10");
            controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
        }
    }

    private void V800_OnClick(object sender, RoutedEventArgs e)
    {
        if (controller.Model.Version != "8.00")
        {
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateStatusbitsFromVersion("8.00");
            controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
        }
    }

    private void V760_OnClick(object sender, RoutedEventArgs e)
    {
        if (controller.Model.Version != "7.60")
        {
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateStatusbitsFromVersion("7.60");
            controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
        }
    }

    private void V750_OnClick(object sender, RoutedEventArgs e)
    {
        if (controller.Model.Version != "7.50")
        {
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateStatusbitsFromVersion("7.50");
            controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
        }
    }

    private void en_OnClick(object sender, RoutedEventArgs e)
    {
        if (controller.Model.Language != "en")
        {
            controller.SetLanguage("en");
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateStatusbitsFromVersion(controller.Model.Version);
            controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
        }        
    }

    private void de_OnClick(object sender, RoutedEventArgs e)
    {
         if(controller.Model.Language != "de")
         {
            controller.SetLanguage("de");
            string value = BinaryTB.Text;
            IList<object> items1 = ActiveBits1.SelectedItems;
            IList<object> items2 = ActiveBits2.SelectedItems;
            IList<object> items3 = ActiveBits3.SelectedItems;
            IList<object> items4 = ActiveBits4.SelectedItems;
            IList<object> items5 = ActiveBits5.SelectedItems;
            IList<object> items6 = ActiveBits6.SelectedItems;
            IList<object> items7 = ActiveBits7.SelectedItems;
            IList<object> items8 = ActiveBits8.SelectedItems;
            controller.UpdateStatusbitsFromVersion(controller.Model.Version);
            controller.UpdateValues(value, "Binary", items8, items7, items6, items5, items4, items3, items2, items1);
         }
    }

    private void AppServiceConnected(object sender, Windows.ApplicationModel.AppService.AppServiceTriggerDetails e)
    {
        e.AppServiceConnection.RequestReceived += AppServiceConnection_RequestReceived;
    }

    private void ActiveBits8_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        resource = new ResourceLoader("Tooltips_" + controller.Model.Language);
        for (int i = 0; i < 8; i++)
        {
            var test = ActiveBits8.ContainerFromIndex(i);
            if (test != null)
            {
                string tooltip = resource.GetString(ActiveBits8.Items[i].ToString().Substring(2));
                test.SetValue(ToolTipService.ToolTipProperty, tooltip);
            }
        }
    }

    private void ActiveBits7_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        resource = new ResourceLoader("Tooltips_" + controller.Model.Language);
        for (int i = 0; i < 8; i++)
        {
            var test = ActiveBits7.ContainerFromIndex(i);
            if (test != null)
            {
                string tooltip = resource.GetString(ActiveBits7.Items[i].ToString().Substring(2));
                test.SetValue(ToolTipService.ToolTipProperty, tooltip);
            }
        }
    }

    private void ActiveBits6_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        resource = new ResourceLoader("Tooltips_" + controller.Model.Language);
        for (int i = 0; i < 8; i++)
        {
            var test = ActiveBits6.ContainerFromIndex(i);
            if (test != null)
            {
                string tooltip = resource.GetString(ActiveBits6.Items[i].ToString().Substring(2));
                test.SetValue(ToolTipService.ToolTipProperty, tooltip);
            }
        }
    }

    private void ActiveBits5_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        resource = new ResourceLoader("Tooltips_" + controller.Model.Language);
        for (int i = 0; i < 8; i++)
        {
            var test = ActiveBits5.ContainerFromIndex(i);
            if (test != null)
            {
                string tooltip = resource.GetString(ActiveBits5.Items[i].ToString().Substring(2));
                test.SetValue(ToolTipService.ToolTipProperty, tooltip);
            }
        }
    }

    private void ActiveBits4_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        resource = new ResourceLoader("Tooltips_" + controller.Model.Language);
        for (int i = 0; i < 8; i++)
        {
            var test = ActiveBits4.ContainerFromIndex(i);
            if (test != null)
            {
                string tooltip = resource.GetString(ActiveBits4.Items[i].ToString().Substring(2));
                test.SetValue(ToolTipService.ToolTipProperty, tooltip);
            }
        }
    }

    private void ActiveBits3_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        resource = new ResourceLoader("Tooltips_" + controller.Model.Language);
        for (int i = 0; i < 8; i++)
        {
            var test = ActiveBits3.ContainerFromIndex(i);
            if (test != null)
            {
                string tooltip = resource.GetString(ActiveBits3.Items[i].ToString().Substring(2));
                test.SetValue(ToolTipService.ToolTipProperty, tooltip);
            }
        }
    }

    private void ActiveBits2_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        resource = new ResourceLoader("Tooltips_" + controller.Model.Language);
        for (int i = 0; i < 8; i++)
        {
            var test = ActiveBits2.ContainerFromIndex(i);
            if (test != null)
            {
                string tooltip = resource.GetString(ActiveBits2.Items[i].ToString().Substring(2));
                test.SetValue(ToolTipService.ToolTipProperty, tooltip);
            }
        }
    }

    private void ActiveBits1_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        resource = new ResourceLoader("Tooltips_" + controller.Model.Language);
        for (int i = 0; i < 8; i++)
        {
            var test = ActiveBits1.ContainerFromIndex(i);
            if (test != null)
            {
                string tooltip = resource.GetString(ActiveBits1.Items[i].ToString().Substring(2));
                test.SetValue(ToolTipService.ToolTipProperty, tooltip);
            }
        }
    }

        private async void AppServiceConnection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
    {
        if (allowed_to_recieve)
        {
            AppServiceDeferral messageDeferral = args.GetDeferral();
            string id = (string)args.Request.Message["ID"];
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                controller.UpdateValues(id, ClipboardType.SelectionBoxItem.ToString(), ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
                 
            });
            await args.Request.SendResponseAsync(new ValueSet());
            messageDeferral.Complete();

            // we no longer need the connection
            App.AppServiceDeferral.Complete();
            App.Connection = null;
        }  
    }
    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
        {
            Process process = Process.GetCurrentProcess();
            ApplicationData.Current.LocalSettings.Values["processID"] = process.Id;

            App.AppServiceConnected += AppServiceConnected;
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }
    }
  }
}
