namespace Sleepwise.Pages.Login;


using Sleepwise.ViewModels;
using Sleepwise;


public partial class LoginPage : ContentPage
{
    UserViewModel viewModel;

    private static string EMAIL_KEY = "email_key", PASSWORD_KEY = "password_key", REMEMBER_ME_KEY = "remember_key";
    public static string Token = null;
    public LoginPage()
    {
        BindingContext = viewModel = new UserViewModel();
        InitializeComponent();
        
        viewModel.OnPropertyChanged("Users");
        EmailEntry.Text = Preferences.Default.Get<string>(EMAIL_KEY, "");
        PasswordEntry.Text = Preferences.Default.Get<string>(PASSWORD_KEY, "");
        RememberMeCheckbox.IsChecked = Preferences.Default.Get<bool>(REMEMBER_ME_KEY, false);
    }
    protected override void OnAppearing()
    {
//        base.OnAppearing();
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        string emailString = EmailEntry.Text;
        string passwordString = PasswordEntry.Text;

        bool userCredentailsValid = viewModel.DoesUserCredentialsExistInDatabase(emailString, passwordString);
        if (userCredentailsValid)
        {
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

            Navigation.PopModalAsync();
            var mainPage = Application.Current.MainPage as MainPage; // Assuming MainPage is your main TabbedPage
            if (mainPage != null)
            {
                Dispatcher.Dispatch(async () =>
                {
                    await Task.Delay(10);
                    //mainPage.CurrentPage = mainPage.Children[0];
                }
                );
            }
        } else
        {
            ErrorMessageLabel.Text = "Invalid credentials. Please try again.";
            ErrorMessageLabel.IsVisible = true;
        }


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

        Dispatcher.Dispatch(async () =>
            await Navigation.PushModalAsync(createAccountPage, false)
        );
    }
}