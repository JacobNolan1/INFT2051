using Sleepwise.Models.Old;
using Sleepwise.Pages.Forms.DaySummary;

namespace Sleepwise.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

        DailySummaryModel nightDailySummaryModel = new DailySummaryModel()
        {
            IsNightSummary=true,
            moodEnum=MoodEnums.Average,
            Insights = new List<InsightEnums> { InsightEnums.Tired },
        };
        DailySummaryModel dayDailySummaryModel = new DailySummaryModel()
        {
            IsDaySummary = true,
            moodEnum = MoodEnums.Bad,
            Insights = new List<InsightEnums> { InsightEnums.Alcohol, InsightEnums.Tired },
        };

        nightDailySummary.BindingContext = nightDailySummaryModel;
        dayDailySummary.BindingContext = dayDailySummaryModel;

        ImpactSummaryModel positiveImpactSummaryModel = new ImpactSummaryModel()
        {
            Title = "Positive Impacts on Sleep",
            Insights = new List<InsightEnums> { InsightEnums.SleepWell, InsightEnums.Tired},
        };

        ImpactSummaryModel negativeImpactSummaryModel = new ImpactSummaryModel()
        {
            Title = "Negative Impacts on Sleep",
            Insights = new List<InsightEnums> { InsightEnums.Alcohol, InsightEnums.Tired},
        };

        positiveImpactSummary.BindingContext = positiveImpactSummaryModel;
        negativeImpactSummary.BindingContext = negativeImpactSummaryModel;

    }

    private async void NavigateToNoTabBarPage(object sender, EventArgs e)
    {
        // Navigate to the NoTabBarPage
        await Navigation.PushAsync(new DayRatingPage());
    }

}