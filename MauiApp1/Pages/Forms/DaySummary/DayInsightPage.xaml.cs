namespace Sleepwise.Pages.Forms.DaySummary;

public partial class DayInsightPage : ContentPage
{
	public DayInsightPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
	}

    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        // Use Navigation property to access the NavigationPage and call PopRootAsync
        if (Navigation is INavigation navigation)
        {
            await navigation.PopToRootAsync();
        }
    }
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        if (Navigation is INavigation navigation)
        {
            await navigation.PopAsync();
        }
    }
}