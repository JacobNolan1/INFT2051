using Sleepwise.Models;
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
using Sleepwise.Pages.Forms.DaySummary;
using System.ComponentModel;
using Sleepwise.Pages.Forms.NightSummary;

namespace Sleepwise.Pages.Breakdown;

public partial class NightBreakdown : ContentPage, INotifyPropertyChanged
{
    private NightTimeInsightViewModel viewModel;
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
    public NightTimeInsightModel SelectedNightTimeInsight
    {
        get { return viewModel.SelectedNightTimeInsight; }
    }

    private int _userId;
    public int UserId
    {
        get { return _userId; }
        set
        {
            if (this._userId != value)
            {
                this._userId = value;
                OnPropertyChanged(nameof(UserId));
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
    public static readonly Dictionary<string, string> moodImageMappings = new Dictionary<string, string>
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

    public NightBreakdown()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
        this.BindingContext = this;
    }
    public NightBreakdown(DateTime SelectedDate, int user_id, string rating)
    {
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        this.SelectedDate = SelectedDate;
        this.UserId = user_id;
        this.Rating = rating;
        this.SetMoodImageFromRating(rating);

        viewModel = new NightTimeInsightViewModel();
        ReloadNightInsight();
        InitializeComponent();
        this.BindingContext = this;
    }
    public void ReloadNightInsight()
    {
        viewModel.LoadNightTimeInsightForDate(UserId, SelectedDate);
    }

    private void DoSummaryButton_Tapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NightRatingPage(SelectedDate), false);
    }
    public event PropertyChangedEventHandler PropertyChanged;

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        if (Navigation is INavigation navigation)
        {
            navigation.PopAsync();
        }
    }

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        if (Navigation is INavigation navigation)
        {
            navigation.PopToRootAsync();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}