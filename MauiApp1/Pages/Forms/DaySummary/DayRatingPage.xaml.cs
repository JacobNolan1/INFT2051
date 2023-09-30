namespace Sleepwise.Pages.Forms.DaySummary;

public partial class DayRatingPage : ContentPage
{
	public DayRatingPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
	}
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton imageButton)
        {
            if (imageButton.CommandParameter is string type)
            {
                // Now you can use the 'type' variable in your logic
                Console.WriteLine($"Button clicked: {type}");
            }
            Navigation.PushAsync(new DayInsightPage());
        }
    }
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        // Use Navigation property to access the NavigationPage and call PopRootAsync
        if (Navigation is INavigation navigation)
        {
            await navigation.PopAsync();
        }
    }
    /*
    private void BackButton_Clicked(object sender, EventArgs e)
    {

//        Navigation.PopModalAsync();
    }
    */
}  