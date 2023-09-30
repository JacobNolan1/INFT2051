namespace Sleepwise.Pages;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
	}
    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new SummaryPage(), false);
        Navigation.PopToRootAsync();
    }

    private void StatsButton_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new StatisticsPage(), false);
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AppSettingsPage(), false);
    }
}