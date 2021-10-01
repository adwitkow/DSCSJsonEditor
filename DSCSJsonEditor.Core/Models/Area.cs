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

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DSCSJsonEditor.Core.Models
{
    public class Area : IStepContainer, INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        public string DisplayName
        {
            get => this.displayName;
            set
            {
                this.displayName = value;
                this.NotifyPropertyChanged();
            }
        }

        public string WikiUrl
        {
            get => this.wikiUrl;
            set
            {
                this.wikiUrl = value;
                this.NotifyPropertyChanged();
            }
        }

        public int Id
        {
            get => this.id;
            set
            {
                this.id = value;
                this.NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Step> Steps
        {
            get => this.steps;
            set
            {
                this.steps = value;
                this.NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
