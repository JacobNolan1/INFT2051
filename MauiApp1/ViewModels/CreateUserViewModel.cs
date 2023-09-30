using Sleepwise.Models;
using Sleepwise.Services;
using Sleepwise.Utils.Validators;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.ViewModels
{

    internal class CreateUserViewModel : ObservableObject
    {
        public static CreateUserViewModel Current { get; set; }
        SQLiteConnection connection;
        private bool _userExistsMessageVisible = false;

        private ObservableValidatorEmail _emailValidator = new ObservableValidatorEmail();
        private ObservableValidatorPassword _passwordValidator = new ObservableValidatorPassword();
        public CreateUserViewModel()
        {
            Current = this;
            connection = DatabaseService.Connection;
        }
        public ObservableValidatorEmail EmailValidator
        {
            get => _emailValidator;
            set
            {
                if (_emailValidator != value)
                {
                    _emailValidator = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableValidatorPassword PasswordValidator
        {
            get => _passwordValidator;
            set
            {
                if (_passwordValidator != value)
                {
                    _passwordValidator = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                    EmailValidator.Validate(_email);
                }
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    PasswordValidator.ValidatePasswordMatch(_password, _passwordConfirm);
                }
            }
        }

        private string _passwordConfirm;
        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set
            {
                if (_passwordConfirm != value)
                {
                    _passwordConfirm = value;
                    OnPropertyChanged();
                    PasswordValidator.ValidatePasswordMatch(_password, _passwordConfirm);
                }
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
        public bool DoesUserExist(string email)
        {
            var existingUser = connection.Table<UserModel>().FirstOrDefault(u => u.Email == email);
            return existingUser != null;
        }        
        public bool UserExistsMessageVisible
        {
            get => _userExistsMessageVisible;
            set
            {
                if (_userExistsMessageVisible != value)
                {
                    _userExistsMessageVisible = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
