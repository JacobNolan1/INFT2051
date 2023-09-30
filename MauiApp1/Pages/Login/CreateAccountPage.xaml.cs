using Sleepwise.Models;
using Sleepwise.ViewModels;

namespace Sleepwise.Pages.Login;

public partial class CreateAccountPage : ContentPage
{
    private CreateUserViewModel viewModel;
    public event EventHandler<string> DataPassedBack;

    public CreateAccountPage()
	{
        viewModel = new CreateUserViewModel();
        BindingContext = viewModel;
        InitializeComponent();
	}
    public CreateAccountPage(string emailString)
    {
        viewModel = new CreateUserViewModel();
        BindingContext = viewModel;
        InitializeComponent();
        if (!string.IsNullOrEmpty(emailString))
        {
            viewModel.Email = emailString;
        }
    }

    private void ReturnButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private void CreateAccountButton_Clicked(object sender, EventArgs e)
    {
        string emailString;
        string passwordString;
        if (viewModel.EmailValidator.IsValid && viewModel.PasswordValidator.IsValid)
        {
            emailString = viewModel.Email;
            passwordString = viewModel.Password;
            if (viewModel.DoesUserExist(emailString))
            {
                // User already exists, set the visibility property to true
                viewModel.UserExistsMessageVisible = true;
            } else
            {
                viewModel.UserExistsMessageVisible = false;
                UserModel userModel = new UserModel
                {
                    Email = emailString,
                    Password = passwordString
                };
                viewModel.SaveUser(userModel);
                OnDataToPassBack(emailString);
                Navigation.PopAsync();
            }
        }
    }
    private void OnDataToPassBack(string data)
    {
        DataPassedBack?.Invoke(this, data);
    }


}