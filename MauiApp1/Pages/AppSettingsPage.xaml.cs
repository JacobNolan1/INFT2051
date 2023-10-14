using Sleepwise.Pages.Login;
using Sleepwise.Services.PartialMethods;
using Sleepwise.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sleepwise.Pages;

public partial class AppSettingsPage : ContentPage
{
    public static event EventHandler LoggedOut;
    public SettingsViewModel ViewModel { get; private set; }
    public AppSettingsPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
        ViewModel = new SettingsViewModel();
        int user_id = Preferences.Default.Get<int>("user_id", -1);
        ViewModel.LoadUserSettings(user_id);
        BindingContext = ViewModel;
    }

    public void ScheduleUpcomingNotificationsForUser(int userID)
    {
        SettingsViewModel settingsViewModel = new SettingsViewModel();
        settingsViewModel.LoadUserSettings(userID);
        TimeSpan morningTime = settingsViewModel.SelectedSettingsModel.DayNotificationTime;
        TimeSpan nightTime = settingsViewModel.SelectedSettingsModel.NightNotificationTime;
        int daysScheduleAheadFor = 7;
        NotificationService.ScheduleMorningAndNightNotifications(daysScheduleAheadFor, morningTime, nightTime);
        NotificationService.GetScheduledToasts();
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

    private void SaveChangesButton_Clicked(object sender, EventArgs e)
    {
        ViewModel.SaveSettings(ViewModel.SelectedSettingsModel);
        Dispatcher.Dispatch(async () =>
            await DisplayAlert("Success", "Changes Saved", "OK")
        );
        int user_id = Preferences.Default.Get<int>("user_id", -1);
        ScheduleUpcomingNotificationsForUser(user_id);
    }
}