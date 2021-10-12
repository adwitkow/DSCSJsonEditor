// This file is part of DSCSJsonEditor project <https://github.com/adwitkow/DSCSJsonEditor>
// Copyright (C) 2021  Adam Witkowski <https://github.com/adwitkow/>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DSCSJsonEditor.Core
{
    public abstract class ValidatableBase : BindableBase, INotifyDataErrorInfo
    {
        private Dictionary<string, ICollection<string>> errors;

        public ValidatableBase()
        {
            this.errors = new Dictionary<string, ICollection<string>>();
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        [JsonIgnore]
        public bool HasErrors => this.errors.Any();

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            this.errors.TryGetValue(propertyName, out var errorCollection);
            return errorCollection;
        }

        protected override bool SetProperty<T>(ref T propertyReference, T newValue, [CallerMemberName] string propertyName = null)
        {
            var success = false;
            var isValid = this.ValidateProperty(propertyName, newValue);
            if (isValid)
            {
                success = base.SetProperty(ref propertyReference, newValue, propertyName);
            }

            return success;
        }

        protected void OnErrorsChanged(string propertyName)
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private bool ValidateProperty<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this)
            {
                MemberName = propertyName,
            };

            var isValid = Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                this.errors[propertyName] = results.Select(result => result.ErrorMessage).ToList();
            }
            else
            {
                this.errors.Remove(propertyName);
            }

            this.OnErrorsChanged(propertyName);
            return isValid;
        }
    }
}
