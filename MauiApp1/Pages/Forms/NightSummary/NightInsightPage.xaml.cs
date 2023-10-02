using Sleepwise.ViewModels;

namespace Sleepwise.Pages.Forms.NightSummary
{
    public partial class NightInsightPage : ContentPage
    {
        public NightInsightViewModel ViewModel { get; private set; }
        public string Rating;
        public NightInsightPage(string rating, DateTime? date = null)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            ViewModel = new NightInsightViewModel();

            if (date == null)
            {
                date = DateTime.Now.Date;
            }
            Rating = rating;
            int user_id = Preferences.Default.Get<int>("user_id", -1);
            ViewModel.LoadNightInsightForDate(user_id, date.Value);
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
            ViewModel.SelectedNightInsight.SummaryRating = Rating;
            ViewModel.SaveNightInsight(ViewModel.SelectedNightInsight);
            if (Navigation is INavigation navigation)
            {
                navigation.PopToRootAsync();
            }
        }
    }
}

