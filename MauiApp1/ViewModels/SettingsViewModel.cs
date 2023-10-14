using Sleepwise.Models;
using Sleepwise.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.ViewModels
{
    public class SettingsViewModel: ObservableObject
    {
        public static SettingsViewModel Current { get; set; }
        private readonly SQLiteConnection _connection;

        public SettingsViewModel()
        {
            Current = this;
            _connection = DatabaseService.Connection;
        }

        private SettingsModel _selectedSettingsModel;

        public SettingsModel SelectedSettingsModel
        {
            get { return _selectedSettingsModel; }
            set
            {
                if (_selectedSettingsModel != value)
                {
                    _selectedSettingsModel = value;
                    OnPropertyChanged(nameof(SelectedSettingsModel));
                }
            }
        }

        public void LoadUserSettings(int userID)
        {
            SelectedSettingsModel = _connection.Table<SettingsModel>()
                .Where(x => x.UserID == userID)
                .FirstOrDefault();

            if (SelectedSettingsModel == null)
            {
                SelectedSettingsModel = new SettingsModel
                {
                    UserID = userID,
                    DayNotificationsEnabled = true,
                    NightNotificationsEnabled = true,
                    DayNotificationTime = TimeSpan.FromHours(8),
                    NightNotificationTime = TimeSpan.FromHours(20),
                };
            }
        }


        
        public void SaveSettings(SettingsModel model)
        {
            if (model.Id > 0)
            {
                _connection.Update(model);
            }
            else
            {
                _connection.Insert(model);
            }
        }

    }
}