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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using DSCSJsonEditor.Core;
using DSCSJsonEditor.Core.Models;
using DSCSJsonEditor.WPF.Events;
using Microsoft.Win32;

namespace DSCSJsonEditor.WPF.ViewModels
{
    public class NavigationViewModel : BindableBase
    {
        private IStepContainer selectedStepContainer;

        private ObservableCollection<Area> areas;

        public NavigationViewModel()
        {
            this.Areas = new ObservableCollection<Area>(this.PopulateAreas());
        }

        public event EventHandler<SelectedStepContainerChangedEventArgs> SelectedStepContainerChanged;

        public ObservableCollection<Area> Areas
        {
            get => this.areas;
            set
            {
                this.SetProperty(ref this.areas, value);
            }
        }

        public IStepContainer SelectedStepContainer
        {
            get => this.selectedStepContainer;
            set
            {
                var oldContainer = this.selectedStepContainer;
                if (this.SetProperty(ref this.selectedStepContainer, value))
                {
                    this.OnSelectedStepChanged(oldContainer, value);
                    this.NotifyPropertyChanged(nameof(this.CanModifyStep));
                }
            }
        }

        public DelegateCommand AddStepCommand => new DelegateCommand(this.AddStep);

        public DelegateCommand RemoveStepCommand => new DelegateCommand(this.RemoveStep);

        public bool CanModifyStep => this.selectedStepContainer != null;

        public DelegateCommand ExportCommand => new DelegateCommand(this.Export);

        public DelegateCommand ImportCommand => new DelegateCommand(this.Import);

        protected void OnSelectedStepChanged(IStepContainer oldStep, IStepContainer newStep)
        {
            this.SelectedStepContainerChanged?.Invoke(this, new SelectedStepContainerChangedEventArgs(oldStep, newStep));
        }

        private void Export(object obj)
        {
            // TODO: Save the serialized data
            Trace.WriteLine(JsonExporter.Export(this.areas));
        }

        private void Import(object obj)
        {
            var dialog = new OpenFileDialog();
            var dialogResult = dialog.ShowDialog();

            // Nullable bool..
            if (dialogResult == true)
            {
                var filePath = dialog.FileName;
                var json = System.IO.File.ReadAllText(filePath);

                this.Areas = new ObservableCollection<Area>(JsonExporter.Import(json));
            }
        }

        private void AddStep(object obj)
        {
            if (this.selectedStepContainer is IStepContainer)
            {
                var newStep = new Step(this.selectedStepContainer, "New Item");
                this.selectedStepContainer.Steps.Add(newStep);
            }
            else
            {
                var newArea = new Area("New Area");
                this.areas.Add(newArea);
            }
        }

        private void RemoveStep(object obj)
        {
            if (this.selectedStepContainer is Step step)
            {
                var parent = step.Parent;
                parent.Steps.Remove(step);
            }
            else if (this.selectedStepContainer is Area area)
            {
                this.areas.Remove(area);
            }
        }

        private IEnumerable<Area> PopulateAreas()
        {
            return Constants.AreaNames.Select(areaName => new Area(areaName));
        }
    }
}