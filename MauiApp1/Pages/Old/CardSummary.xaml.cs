using Sleepwise.Models.Old;

namespace Sleepwise.Pages
{
    public partial class CardSummary : ContentView
    {
        DailySummaryModel model;

        public CardSummary()
        {
            InitializeComponent();
        }
        public DailySummaryModel SummaryModel
        {
            get { return (DailySummaryModel)BindingContext; }
            set { BindingContext = value; }
        }
    }
}
