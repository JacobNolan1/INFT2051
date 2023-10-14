using Sleepwise.Models;
using Sleepwise.Services.PartialMethods;
using Sleepwise.ViewModels;

namespace Sleepwise.Pages.Login;

public partial class UserLoginPage : ContentPage
{
    UserViewModel viewModel;
    private static string EMAIL_KEY = "email_key", PASSWORD_KEY = "password_key", REMEMBER_ME_KEY = "remember_key";
    public static string Token = null;

    public UserLoginPage()
	{
        BindingContext = viewModel = new UserViewModel();
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();

        viewModel.OnPropertyChanged("Users");
        EmailEntry.Text = Preferences.Default.Get<string>(EMAIL_KEY, "");
        PasswordEntry.Text = Preferences.Default.Get<string>(PASSWORD_KEY, "");
        RememberMeCheckbox.IsChecked = Preferences.Default.Get<bool>(REMEMBER_ME_KEY, false);
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        string emailString = EmailEntry.Text;
        string passwordString = PasswordEntry.Text;

        UserModel userModel = viewModel.DoesUserCredentialsExistInDatabase(emailString, passwordString);
        bool userCredentailsValid = userModel != null;
        if (userCredentailsValid)
        {
            Preferences.Set("user_id", userModel.Id);
            ErrorMessageLabel.IsVisible = false;

            if (RememberMeCheckbox.IsChecked)
            {
                Preferences.Set(EMAIL_KEY, EmailEntry.Text);
                Preferences.Set(PASSWORD_KEY, PasswordEntry.Text);
                Preferences.Set(REMEMBER_ME_KEY, true);
            }
            else
            {
                Preferences.Default.Remove(EMAIL_KEY);
                Preferences.Default.Remove(PASSWORD_KEY);
                Preferences.Default.Remove(REMEMBER_ME_KEY);
            }

            Token = "justafaketoken";
            ScheduleUpcomingNotificationsForUser(userModel.Id);
            Navigation.PopAsync();
            /*
            var mainPage = Application.Current.MainPage as MainPage;
            if (mainPage != null)
            {
                Dispatcher.Dispatch(async () =>
                {
                    await Task.Delay(10);
                    mainPage.CurrentPage = mainPage.Children[0];
                }
                );
            }
            */
        }
        else
        {
            Preferences.Remove("user_id");
            ErrorMessageLabel.Text = "Invalid credentials. Please try again.";
            ErrorMessageLabel.IsVisible = true;
        }
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
    private void CreateAccountButton_Clicked(object sender, EventArgs e)
    {
        string emailString = EmailEntry.Text;

        CreateAccountPage createAccountPage = new CreateAccountPage(emailString);
        createAccountPage.DataPassedBack += (sender, data) =>
        {
            if (data != "" && data != null)
            {
                EmailEntry.Text = data;
            }
        };
        Navigation.PushModalAsync(createAccountPage, false);
    }

}