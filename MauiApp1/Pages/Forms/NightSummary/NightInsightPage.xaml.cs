using Microsoft.Maui.Controls;
using Sleepwise.Models;
using Sleepwise.Utils;
using Sleepwise.ViewModels;

namespace Sleepwise.Pages.Forms.NightSummary
{
    public partial class NightInsightPage : ContentPage
    {
        public NightTimeInsightViewModel ViewModel { get; private set; }
        public string Rating;

        public NightInsightPage(string rating, DateTime? date = null)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            ViewModel = new NightTimeInsightViewModel();

            if (date == null)
            {
                date = DateTime.Now.Date;
            }
            Rating = rating;
            int user_id = Preferences.Default.Get<int>("user_id", -1);
            ViewModel.LoadNightTimeInsightForDate(user_id, date.Value);
            BindingContext = ViewModel;
        }


        private void BackButton_Clicked(object sender, EventArgs e)
        {
            if (Navigation is INavigation navigation)
            {
                navigation.PopAsync();
            }
        }

        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            if (Navigation is INavigation navigation)
            {
                navigation.PopToRootAsync();
            }
        }


        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.SelectedNightTimeInsight.SummaryRating = Rating;
            ViewModel.SaveNightTimeInsight(ViewModel.SelectedNightTimeInsight);
            if (Navigation is INavigation navigation)
            {
                MessagingCenter.Send(new StringMessage(), "SubmitButtonClicked");
                navigation.PopToRootAsync();
            }
        }
    }
}