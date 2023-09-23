using Sleepwise.Pages;
using Sleepwise.Utils;

namespace Sleepwise;

public partial class AppShell : Shell
{
    MessageBus messageBus = MessageBus.Instance;
    NavigationPagesEnums displayedPage = NavigationPagesEnums.Main;

	public AppShell()
	{
		InitializeComponent();

        messageBus.Subscribe<string>("UpdateDisplayedPage", message =>
        {
            NavigationPagesEnums enumValue;

            // System.Diagnostics.Debug.WriteLine($"Received message: {message}");
            if (Enum.TryParse(message, out enumValue))
            {
                System.Diagnostics.Debug.WriteLine($"Received message: {enumValue}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No Match");
                // Handle invalid string value or enum value not found.
                // You can add error handling here.
            }
        });
    }


}
