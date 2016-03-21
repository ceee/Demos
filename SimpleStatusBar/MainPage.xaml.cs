using System;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace SimpleStatusBar
{
  public sealed partial class MainPage : Page
  {
    private bool isStatusBarToggled = false;


    public MainPage()
    {
      this.InitializeComponent();
    }


    private async void ToggleStatusBar_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
      // check if the status bar is available (will be false on desktop)
      if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
      {
        StatusBarProgressIndicator indicator = StatusBar.GetForCurrentView().ProgressIndicator;

        isStatusBarToggled = !isStatusBarToggled;

        if (isStatusBarToggled)
        {
          // show the progress indicator and set it's value to 0.
          await indicator.ShowAsync();
          indicator.ProgressValue = 0;

          // the space here is the required hack,
          // as it will hide all other controls to make room for the progress text,
          // which is invisible here because it's only a space
          indicator.Text = " ";
        }
        else
        {
          await indicator.HideAsync();
          indicator.ProgressValue = null;
          indicator.Text = String.Empty;
        }
      }
    }
  }
}
