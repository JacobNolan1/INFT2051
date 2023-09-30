namespace Sleepwise.Pages;

public partial class SummaryPage : ContentPage
{
	public SummaryPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
	}
    private void DailySummaryButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Forms.DaySummary.DayRatingPage(), false);
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