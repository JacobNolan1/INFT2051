using Sleepwise.Pages.Forms.DaySummary;


namespace Sleepwise.Pages
{
    public partial class InsightContainer : ContentView
    {
        public static readonly BindableProperty SelectedDateProperty =
            BindableProperty.Create(nameof(SelectedDate), typeof(DateTime), typeof(InsightContainer));

        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public InsightContainer()
        {
            InitializeComponent();
        }

        public InsightContainer(DateTime selectedDate)
        {
            InitializeComponent();
            SelectedDate = selectedDate;
        }

        private void DoSummaryButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DayTimeRatingPage(SelectedDate), false);
        }
    }
}