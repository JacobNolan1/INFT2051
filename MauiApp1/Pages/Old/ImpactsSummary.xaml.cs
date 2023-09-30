using Sleepwise.Models.Old;

namespace Sleepwise.Pages;

public partial class ImpactsSummary : ContentView
{

	ImpactSummaryModel model;
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(ImpactsSummary),
        "Default Title"
    );
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }



    public ImpactsSummary()
	{
        InitializeComponent();
	}
}