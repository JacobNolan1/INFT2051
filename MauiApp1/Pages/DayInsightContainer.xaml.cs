using Sleepwise.Models;
using Sleepwise.Pages.Breakdown;
using Sleepwise.Pages.Forms.DaySummary;
using Sleepwise.Services;
using Sleepwise.Utils;
using Sleepwise.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sleepwise.Pages
{
    public partial class DayInsightContainer : ContentView, INotifyPropertyChanged
    {

        private bool _isSummaryDone;

        public bool IsSummaryDone
        {
            get { return _isSummaryDone; }
            set
            {
                if (_isSummaryDone != value)
                {
                    _isSummaryDone = value;
                    OnPropertyChanged(nameof(IsSummaryDone));
                }
            }
        }
        private bool _isSummaryNotDone;

        public bool IsSummaryNotDone
        {
            get { return _isSummaryNotDone; }
            set
            {
                if (_isSummaryNotDone != value)
                {
                    _isSummaryNotDone = value;
                    OnPropertyChanged(nameof(IsSummaryNotDone));
                }
            }
        }



        private string _rating;

        public string Rating
        {
            get { return _rating; }
            set
            {
                if (this._rating != value)
                {
                    this._rating = value;
                    OnPropertyChanged(nameof(_rating));
                }
            }
        }

        public static readonly Dictionary<string, string> moodImageMappings= new Dictionary<string, string>
        {
            { "terrible", "sad_full.png"},
            { "bad", "sad.png"},
            { "average", "meh.png"},
            { "good", "happy.png"},
            { "amazing", "happy_full.png"}
        };
        private ImageSource moodImage;
        public ImageSource MoodImage
        {
            get
            {
                if (Rating == null) { return null; }
                return moodImageMappings.GetValueOrDefault(Rating, string.Empty);
            }
            set
            {
                if (moodImage != value)
                {
                    moodImage = value;
                    OnPropertyChanged(nameof(MoodImage));
                }
            }
        }


        public void SetMoodImageFromRating(string rating)
        {
            if (rating == null) { return; }
            MoodImage = moodImageMappings.GetValueOrDefault(rating, string.Empty);
        }

        public int user_id;

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (this._selectedDate != value)
                {
                    this._selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        private DayTimeInsightViewModel viewModel;

        public DayInsightContainer()
        {
            SelectedDate = DateTime.Now.Date;
            user_id = Preferences.Default.Get<int>("user_id", -1);
            viewModel = new DayTimeInsightViewModel();
            ReloadDayInsight();
            InitializeComponent();
            this.BindingContext = this;

            MessagingCenter.Subscribe<StringMessage>(this, "SubmitButtonClicked", (sender) =>
            {
                ReloadDayInsight();
            });
            MessagingCenter.Subscribe<StringMessage>(this, "GoBackDate", (sender) =>
            {
                SelectedDate = SelectedDate.AddDays(-1);
                ReloadDayInsight();
            });
            MessagingCenter.Subscribe<StringMessage>(this, "GoCurrentDate", (sender) =>
            {
                SelectedDate = DateTime.Now.Date;
                ReloadDayInsight();
            });
            MessagingCenter.Subscribe<StringMessage>(this, "GoForwardDate", (sender) =>
            {
                DateTime tomorrow = SelectedDate.AddDays(1);
                if (tomorrow <= DateTime.Now.Date)
                {
                    SelectedDate = tomorrow;
                    ReloadDayInsight();
                }
            });
        }




    private void DoSummaryButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DayTimeRatingPage(SelectedDate), false);
        }
        private void ViewHistory_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DayBreakdown(SelectedDate, user_id, Rating), false);
        }


        public void ReloadDayInsight()
        {
            user_id = Preferences.Default.Get<int>("user_id", -1);
            viewModel.LoadDayTimeInsightForDate(user_id, SelectedDate);
            IsSummaryDone = viewModel.SelectedDayTimeInsight.IsCompleted;
            IsSummaryNotDone = !IsSummaryDone;
            Rating = viewModel.SelectedDayTimeInsight.SummaryRating;
            SetMoodImageFromRating(Rating);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
