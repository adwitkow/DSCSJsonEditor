﻿// This file is part of DSCSJsonEditor project <https://github.com/adwitkow/DSCSJsonEditor>
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DSCSJsonEditor.Core.Models;

namespace DSCSJsonEditor.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IStepContainer selectedStepContainer;
        private Step selectedStep;
        private ObservableCollection<Area> areas;

        public MainViewModel()
        {
            this.Entities = new ObservableCollection<Entity>();
            this.Entities.CollectionChanged += this.Entities_CollectionChanged;

            this.Areas = new ObservableCollection<Area>(this.PopulateAreas());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Area> Areas
        {
            get => this.areas;
            set
            {
                this.areas = value;
                this.NotifyPropertyChanged();
            }
        }

        public IStepContainer SelectedStepContainer
        {
            get => this.selectedStepContainer;
            set
            {
                this.selectedStepContainer = value;
                this.NotifyPropertyChanged(nameof(this.CanAddStep));
            }
        }

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

        public bool CanAddStep => this.SelectedStepContainer != null;

        public DelegateCommand AddStepCommand => new DelegateCommand(this.AddStep);

        public bool CanRemoveStep => this.SelectedStep != null;

        public DelegateCommand RemoveStepCommand => new DelegateCommand(this.RemoveStep);

        public ObservableCollection<Entity> Entities { get; set; }

        private void Entities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.selectedStep is null)
            {
                return;
            }

            this.selectedStep.Entities = this.Entities;
        }

        private void AddStep(object obj)
        {
            this.selectedStepContainer.Steps.Add(new Step("New Item"));
        }

        private void RemoveStep(object obj)
        {
            throw new NotImplementedException();
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
