using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sleepwise.Models
{
    [SQLite.Table("settings")]
    public class SettingsModel : INotifyPropertyChanged
    {
        public SettingsModel()
        {
            _dayNotificationsEnabled = true;
            _nightNotificationsEnabled = true;
            DayNotificationTime = TimeSpan.FromHours(8);
            NightNotificationTime = TimeSpan.FromHours(20);
        }


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private bool _dayNotificationsEnabled;
        public bool DayNotificationsEnabled
        {
            get { return _dayNotificationsEnabled; }
            set { _dayNotificationsEnabled = value; }
        }


        private bool _nightNotificationsEnabled;
        public bool NightNotificationsEnabled
        {
            get { return _nightNotificationsEnabled; }
            set { _nightNotificationsEnabled = value; }
        }


        private TimeSpan _dayNotificationTime;
        public TimeSpan DayNotificationTime
        {
            get { return _dayNotificationTime; }
            set { _dayNotificationTime = value; }
        }

        private TimeSpan _nightNotificationTime;
        public TimeSpan NightNotificationTime
        {
            get { return _nightNotificationTime; }
            set { _nightNotificationTime = value; }
        }



        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
