using Sleepwise.Models;
using Sleepwise.Services;
using SQLite;

namespace Sleepwise.ViewModels
{
    internal class UserViewModel : ObservableObject
    {
        public static UserViewModel Current { get; set; }
        SQLiteConnection connection;

        public UserViewModel() {
            Current = this;
            connection = DatabaseService.Connection;
        }      

        public List<UserModel> Users
        {
            get
            {
                return connection.Table<UserModel>().ToList();
            }
        }

        public void SaveUser(UserModel model)
        {
            //If it has an Id, then it already exists and we can update it
            if (model.Id > 0)
            {
                connection.Update(model);
            }
            //If not, it's new and we need to add it
            else
            {
                connection.Insert(model);
            }
        }
        public void DeleteUser(UserModel model)
        {
            //If it has an Id, then we can delete it
            if (model.Id > 0)
            {
                connection.Delete(model);
            }
        }
        public bool DoesUserCredentialsExistInDatabase(string email, string password)
        {
            var existingUser = connection.Table<UserModel>().FirstOrDefault(u => u.Email == email && u.Password == password);
            return existingUser != null;
        }
    }
}
