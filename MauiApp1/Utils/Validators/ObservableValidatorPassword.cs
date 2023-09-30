using Sleepwise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
namespace Sleepwise.Utils.Validators
{
    internal class ObservableValidatorPassword: ObservableObject { 
        private string _errorText;
        private bool _isValid;

        public string ErrorText
        {
            get => _errorText;
            set
            {
                if (_errorText != value)
                {
                    _errorText = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValid
        {
            get => _isValid;
            set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ValidatePasswordMatch(string password, string passwordConfirm, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordConfirm))
            {
                ErrorText = "Both password fields are required.";
                IsValid = false;
                return false;
            }

            if (password != passwordConfirm)
            {
                ErrorText = "Passwords do not match.";
                IsValid = false;
                return false;
            }
            ErrorText = string.Empty;
            IsValid = true;
            return true;
        }

    }
}
