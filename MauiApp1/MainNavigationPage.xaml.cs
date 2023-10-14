using System;
using System.ComponentModel;
using Sleepwise.Pages;
using Sleepwise.Pages.Forms.DaySummary;
using Sleepwise.Pages.Forms.NightSummary;
using Sleepwise.Pages.Login;
using Sleepwise.Services;
using Sleepwise.Services.PartialMethods;
using Sleepwise.Utils;
using Sleepwise.ViewModels;

namespace Sleepwise
{
    public partial class MainNavigationPage : ContentPage, INotifyPropertyChanged
    {
        private DateTime selectedDate = DateTime.Now.Date;


        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate)); // Notify the UI that the property has changed
                }
            }
        }

        public MainNavigationPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            AppSettingsPage.LoggedOut += AppSettingsPage_LoggedOut;
            SelectedDate = DateTime.Now.Date;
            InitializeComponent();
            this.BindingContext = this;
            if (UserLoginPage.Token != null)
            {
                //ScheduleUpcomingNotificationsForUser();
            }
        }

        public void ScheduleUpcomingNotificationsForUser()
        {
            SettingsViewModel a = new SettingsViewModel();
            TimeSpan morningTime = new TimeSpan(8, 0, 0);
            TimeSpan nightTime = new TimeSpan(20, 0, 0);
            int daysScheduleAheadFor = 7;
            NotificationService.ScheduleMorningAndNightNotifications(daysScheduleAheadFor, morningTime, nightTime);
            NotificationService.GetScheduledToasts();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (UserLoginPage.Token == null)
            {
                Navigation.PushAsync(new UserLoginPage(), false);
            }
        }

        private void AppSettingsPage_LoggedOut(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserLoginPage(), false);
        }

        private void DailySummaryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DayTimeRatingPage(SelectedDate), false);
        }

        private void NightSummaryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NightRatingPage(SelectedDate), false);
        }

        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new SummaryPage(), false);
        }

        private void StatsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StatisticsPage(), false);
        }

        private void SettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppSettingsPage(), false);
        }

        private void GoBackDateButton_Clicked(object sender, EventArgs e)
        {
            SelectedDate = SelectedDate.AddDays(-1);
            MessagingCenter.Send(new StringMessage(), "GoBackDate");
        }

        private void GoToCurrentDateButton_Clicked(object sender, EventArgs e)
        {
            SelectedDate = DateTime.Now.Date;
            MessagingCenter.Send(new StringMessage(), "GoCurrentDate");
        }

        private void GoForwardDateButton_Clicked(object sender, EventArgs e)
        {
            DateTime tomorrow = SelectedDate.AddDays(1);
            if (tomorrow <= DateTime.Now.Date)
            {
                SelectedDate = tomorrow;
                MessagingCenter.Send(new StringMessage(), "GoForwardDate");
            }
            DateTime scheduleTime = DateTime.Now + new TimeSpan(0, 0, 1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
