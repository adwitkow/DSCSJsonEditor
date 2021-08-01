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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DSCSJsonEditor.Models;

namespace DSCSJsonEditor.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Step selectedStep;

        public MainViewModel()
        {
            this.Entities = new BindingList<Entity>();
            this.Entities.RaiseListChangedEvents = true;
            this.Entities.ListChanged += this.Entities_ListChanged;

            this.Areas = this.PopulateAreas();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<Area> Areas { get; set; }

        public Step SelectedStep
        {
            get => this.selectedStep;
            set
            {
                this.selectedStep = value;
                this.BindEntities(value);
                this.NotifyPropertyChanged(nameof(this.Description));
            }
        }

        public string Description
        {
            get => this.SelectedStep?.Description;
            set
            {
                if (this.selectedStep is null)
                {
                    return;
                }

                this.SelectedStep.Description = value;
                this.NotifyPropertyChanged();
            }
        }

        public BindingList<Entity> Entities { get; set; }

        private void Entities_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (this.selectedStep is null)
            {
                return;
            }

            this.selectedStep.Entities = this.Entities;
        }

        private IEnumerable<Area> PopulateAreas()
        {
            return Constants.AreaNames.Select(areaName => new Area(areaName));
        }

        private void BindEntities(Step step)
        {
            this.Entities.Clear();

            if (step is null)
            {
                return;
            }

            foreach (var entity in step.Entities)
            {
                this.Entities.Add(entity);
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
