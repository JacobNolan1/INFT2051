using Sleepwise.Models;

namespace Sleepwise.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        // Create an instance of ImpactSummaryModel
        ImpactSummaryModel positiveImpactSummaryModel = new ImpactSummaryModel()
        {
            Title = "Positive Impacts on Sleep",
            Insights = new List<InsightEnums> { InsightEnums.SleepWell},
        };

        ImpactSummaryModel negativeImpactSummaryModel = new ImpactSummaryModel()
        {
            Title = "Negative Impacts on Sleep",
            Insights = new List<InsightEnums> { InsightEnums.Alcohol, InsightEnums.Tired},
        };

        // Set the BindingContext for the first ImpactSummary component
        positiveImpactSummary.BindingContext = positiveImpactSummaryModel;

        // Set the BindingContext for the second ImpactSummary component
        negativeImpactSummary.BindingContext = negativeImpactSummaryModel;
    }
}