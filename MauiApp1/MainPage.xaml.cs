using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Sleepwise.Pages.MainPage;
using Sleepwise.Utils;

namespace Sleepwise
{
    public partial class MainPage : ContentPage
    {
        private bool isMainPage = true; // Initial value, can be set as needed
        private ContentView contentView;

        private Button toggleButton; // Added a Button field

        public MainPage()
        {
            InitializeComponent();

            contentView = new ContentView
            {
                Content = (isMainPage) ? new FirstPage() : new OtherPage()
            };

            toggleButton = new Button { Text = "Toggle Page" }; // Create the button
            toggleButton.Clicked += OnTogglePageClicked; // Subscribe to the Clicked event

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Main Page", IsVisible = isMainPage },
                    new Label { Text = "Other Page", IsVisible = !isMainPage },
                    contentView,
                    toggleButton
                }
            };
        }

        private void OnTogglePageClicked(object sender, EventArgs e)
        {
            isMainPage = !isMainPage;
            contentView.Content = (isMainPage) ? new FirstPage() : new OtherPage();
        }
    }
}