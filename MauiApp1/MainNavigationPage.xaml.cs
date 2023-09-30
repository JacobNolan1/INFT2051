using Sleepwise.Pages.Forms.DaySummary;

namespace Sleepwise;

using Microsoft.Maui.Controls.Compatibility;
using Sleepwise.Pages;
using Sleepwise.Pages.Login;
using Sleepwise.Pages.Forms.DaySummary;
public partial class MainNavigationPage : ContentPage
    {
        public MainNavigationPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            AppSettingsPage.LoggedOut += AppSettingsPage_LoggedOut;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (UserLoginPage.Token == null)
            {
                Navigation.PushAsync(new UserLoginPage(), false);
            }
        }
        private void AppSettingsPage_LoggedOut(object sender, EventArgs e) { 
        
            Navigation.PushAsync(new UserLoginPage(), false);
        }

    private void DailySummaryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DayRatingPage(), false);
        }


        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new SummaryPage(), false);
        }

        private void StatsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StatisticsPage(), false);
        }

        private void SettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppSettingsPage(), false);
        }
}

