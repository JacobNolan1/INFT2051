using Sleepwise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace Sleepwise.Utils.Validators
{
    internal class ObservableValidatorEmail: ObservableObject
    {
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

        public bool Validate(string input, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                ErrorText = "Field is required.";
                IsValid = false;
                return false;
            }

            if (propertyName == "Email")
            {
                if (!IsValidEmail(input))
                {
                    ErrorText = "Invalid email format.";
                    IsValid = false;
                    return false;
                }
            }

           
            ErrorText = string.Empty;
            IsValid = true;
            return true;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
