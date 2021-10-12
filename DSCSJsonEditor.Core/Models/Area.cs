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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DSCSJsonEditor.Core.Models
{
    public class Area : ValidatableBase, IStepContainer
    {
        private string name;
        private string displayName;
        private string wikiUrl;
        private int id;
        private ObservableCollection<Step> steps;

        public Area(string displayName)
        {
            this.DisplayName = displayName;

            this.Steps = new ObservableCollection<Step>();
        }

        [Required]
        public string Name
        {
            get => this.name;
            set
            {
                this.SetProperty(ref this.name, value);
            }
        }

        [Required]
        public string DisplayName
        {
            get => this.displayName;
            set
            {
                this.SetProperty(ref this.displayName, value);
            }
        }

        [Required]
        public string WikiUrl
        {
            get => this.wikiUrl;
            set
            {
                this.SetProperty(ref this.wikiUrl, value);
            }
        }

        [Required]
        public int Id
        {
            get => this.id;
            set
            {
                this.SetProperty(ref this.id, value);
            }
        }

        public ObservableCollection<Step> Steps
        {
            get => this.steps;
            set
            {
                this.SetProperty(ref this.steps, value);
            }
        }
    }
}
