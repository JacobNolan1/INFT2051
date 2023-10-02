using Microsoft.Maui.Controls;
using Sleepwise.Models;
using Sleepwise.Utils;
using Sleepwise.ViewModels;

namespace Sleepwise.Pages.Forms.DaySummary;

public partial class DayTimeInsightPage : ContentPage
{
    public DayTimeInsightViewModel ViewModel { get; private set; }
    public string Rating;

    public DayTimeInsightPage(string rating, DateTime? date = null)
    {
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
        ViewModel = new DayTimeInsightViewModel();

        if (date == null)
        {
            date = DateTime.Now.Date;
        }
        Rating = rating;
        int user_id = Preferences.Default.Get<int>("user_id", -1);
        ViewModel.LoadDayTimeInsightForDate(user_id, date.Value);
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
        ViewModel.SelectedDayTimeInsight.SummaryRating = Rating;
        ViewModel.SaveDayTimeInsight(ViewModel.SelectedDayTimeInsight);
        if (Navigation is INavigation navigation)
        {
            MessagingCenter.Send(new StringMessage(), "SubmitButtonClicked");
            navigation.PopToRootAsync();
        }
    }
}