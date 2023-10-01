namespace Sleepwise.Pages.Forms.NightSummary;

public partial class NightRatingPage : ContentPage
{
    public DateTime date;
	public NightRatingPage(DateTime? date = null)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();

        if (date == null)
        {
            date = DateTime.Now.Date;
        }
        this.date = (DateTime)date;
        int user_id = Preferences.Default.Get<int>("user_id", -1);
    }
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton imageButton)
        {
            if (imageButton.CommandParameter is string ratingType)
            {
                Console.WriteLine($"Button clicked: {ratingType}");
                Navigation.PushAsync(new NightInsightPage(ratingType, date));
            }
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