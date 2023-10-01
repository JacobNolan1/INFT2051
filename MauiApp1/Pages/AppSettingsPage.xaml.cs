using Sleepwise.Pages.Login;

namespace Sleepwise.Pages;

public partial class AppSettingsPage : ContentPage
{
    public static event EventHandler LoggedOut;

    public AppSettingsPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
	}
    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        LoginPage.Token = null;
        Preferences.Remove("user_id");
        await Navigation.PopToRootAsync();
        LoggedOut?.Invoke(this, EventArgs.Empty);
    }
    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }

    private void StatsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StatisticsPage(), false);
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new AppSettingsPage(), false);
    }
}