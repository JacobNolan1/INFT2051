namespace Sleepwise.Pages.Forms.DaySummary;

public partial class DayTimeRatingPage : ContentPage
{
    public DateTime date { get; set; } 
    public DayTimeRatingPage(DateTime? date = null)
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
        this.BindingContext = this;
    }
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton imageButton)
        {
            if (imageButton.CommandParameter is string ratingType)
            {
                Console.WriteLine($"Button clicked: {ratingType}");
                Navigation.PushAsync(new DayTimeInsightPage(ratingType, date));
            }
        }
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
}