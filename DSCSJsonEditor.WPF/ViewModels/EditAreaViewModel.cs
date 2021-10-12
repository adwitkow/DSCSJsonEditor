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

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DSCSJsonEditor.Core;
using DSCSJsonEditor.Core.Models;

namespace DSCSJsonEditor.WPF.ViewModels
{
    public class EditAreaViewModel : ValidatableBase
    {
        private Area selectedArea;
        private string id;

        public EditAreaViewModel(AreaContainer container)
        {
            this.AreaContainer = container;
        }

        public AreaContainer AreaContainer { get; }

        public Area SelectedArea
        {
            get => this.selectedArea;
            set
            {
                this.SetProperty(ref this.selectedArea, value);
                this.id = this.selectedArea.Id.ToString();
                this.NotifyPropertyChanged(nameof(this.Id));
            }
        }

        [CustomValidation(typeof(EditAreaViewModel), nameof(ValidateId))]
        public string Id
        {
            get => this.id;
            set
            {
                if (this.SetProperty(ref this.id, value))
                {
                    var intValue = int.Parse(value);
                    this.selectedArea.Id = intValue;
                }
            }
        }

        public static ValidationResult ValidateId(string id, ValidationContext context)
        {
            var viewModel = context.ObjectInstance as EditAreaViewModel;

            if (string.IsNullOrEmpty(id))
            {
                return new ValidationResult("ID cannot be empty.");
            }

            var isInt = int.TryParse(id, out int intId);

            if (!isInt)
            {
                return new ValidationResult("ID must be a number.");
            }

            var takenIds = viewModel.AreaContainer.Areas.Select(area => area.Id);
            if (takenIds.Contains(intId))
            {
                return new ValidationResult($"ID {intId} is already taken.");
            }

            return null;
        }
    }
}
