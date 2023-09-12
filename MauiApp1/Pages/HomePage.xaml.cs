using Sleepwise.Models;

namespace Sleepwise.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

        DailySummaryModel nightDailySummaryModel = new DailySummaryModel()
        {
            IsNightSummary=true,
            moodEnum=MoodEnums.Amazing,
            Insights = new List<InsightEnums> { InsightEnums.SleepWell },
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
}