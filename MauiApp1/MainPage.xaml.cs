namespace Sleepwise;

using Sleepwise.Models;
using Sleepwise.Pages.Login;
using Sleepwise.Utils;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
    }
}