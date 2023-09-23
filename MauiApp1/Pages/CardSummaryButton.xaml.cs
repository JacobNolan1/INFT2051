using Sleepwise.Utils;

namespace Sleepwise.Pages;

public partial class CardSummaryButton : ContentView
{
    MessageBus messageBus = MessageBus.Instance;

    string _SummaryMode;
    public string SummaryMode
    {
        get
        {
            return _SummaryMode;
        }
        set
        {
            if (value != _SummaryMode)
            {
                _SummaryMode = value;
            }
        }
    }

    public CardSummaryButton()
	{
		InitializeComponent();
	}
    private void ImageButton_Tapped(object sender, EventArgs e)
    {
        messageBus.Publish("UpdateDisplayedPage", "DaySummary");
    }
}