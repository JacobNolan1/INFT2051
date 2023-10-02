using Sleepwise.Pages.Forms.NightSummary;

namespace Sleepwise.Pages;

public partial class NightInsightContainer : ContentView
{
    public static readonly BindableProperty SelectedDateProperty =
        BindableProperty.Create(nameof(SelectedDate), typeof(DateTime), typeof(InsightContainer));

    public DateTime SelectedDate
    {
        get { return (DateTime)GetValue(SelectedDateProperty); }
        set { SetValue(SelectedDateProperty, value); }
    }

    public NightInsightContainer()
    {
        InitializeComponent();
    }

    public NightInsightContainer(DateTime selectedDate)
    {
        InitializeComponent();
        SelectedDate = selectedDate;
    }

    private void DoSummaryButton_Tapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NightRatingPage(SelectedDate), false);
    }
}
