using Sleepwise.Models;
using Sleepwise.ViewModels;

namespace Sleepwise.Pages;

public partial class StatisticsPage : ContentPage
{
    private DayTimeRatingInsightViewModel viewModelDay;
    private NightTimeRatingInsightViewModel viewModelNight;

    public List<DayTimeRatingInsightModel> positiveDayList { get; set; }
    public List<DayTimeRatingInsightModel> negativeDayList { get; set; }
    public List<NightTimeRatingInsightModel> positiveNightList { get; set; }
    public List<NightTimeRatingInsightModel> negativeNightList { get; set; }
    public string a{ get; set; }

    public bool positiveDayListLength { get; set; }
    public bool negativeDayListLength { get; set; }
    public bool positiveNightListLength { get; set; }
    public bool negativeNightListLength { get; set; }

    public StatisticsPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        a = "No Insights Could Be Developed Yet";
        viewModelDay = new DayTimeRatingInsightViewModel();
        viewModelNight = new NightTimeRatingInsightViewModel();
        positiveDayList = viewModelDay.LoadPositiveRatingInsight();
        negativeDayList = viewModelDay.LoadNegativeRatingInsight();
        positiveNightList = viewModelNight.LoadPositiveRatingInsight();
        negativeNightList = viewModelNight.LoadNegativeRatingInsight();

        positiveDayListLength = positiveDayList.Count <= 0;
        negativeDayListLength = negativeDayList.Count <= 0;
        positiveNightListLength = positiveNightList.Count <= 0;
        negativeNightListLength = negativeNightList.Count <= 0;
        InitializeComponent();
        this.BindingContext = this;
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