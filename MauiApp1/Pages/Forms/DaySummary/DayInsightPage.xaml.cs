using System;
using Sleepwise.ViewModels;

namespace Sleepwise.Pages.Forms.DaySummary
{
    public partial class DayInsightPage : ContentPage
    {
        public DayInsightPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            var viewModel = new DayInsightViewModel();
            BindingContext = viewModel;
        }

        private async void HomeButton_Clicked(object sender, EventArgs e)
        {
            if (Navigation is INavigation navigation)
            {
                await navigation.PopToRootAsync();
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            if (Navigation is INavigation navigation)
            {
                await navigation.PopAsync();
            }
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is DayInsightViewModel viewModel)
            {
                viewModel.SaveDayInsight();
            }

            if (Navigation is INavigation navigation)
            {
                navigation.PopToRootAsync();
            }
        }
    }
}
