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
    public class NavigationViewModel : ViewModelBase
    {
        private IStepContainer selectedStepContainer;
        private Step selectedStep;

        private ObservableCollection<Area> areas;

        public NavigationViewModel()
        {
            this.Areas = new ObservableCollection<Area>(this.PopulateAreas());
        }

        public event EventHandler<SelectedStepChangedEventArgs> SelectedStepChanged;

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
                if (this.SetProperty(ref this.selectedStepContainer, value))
                {
                    this.NotifyPropertyChanged(nameof(this.CanAddStep));
                }
            }
        }

        public Step SelectedStep
        {
            get => this.selectedStep;
            set
            {
                var oldStep = this.selectedStep;
                if (this.SetProperty(ref this.selectedStep, value))
                {
                    this.OnSelectedStepChanged(oldStep, value);
                    this.NotifyPropertyChanged(nameof(this.CanRemoveStep));
                }
            }
        }

        public DelegateCommand AddStepCommand => new DelegateCommand(this.AddStep);

        public DelegateCommand RemoveStepCommand => new DelegateCommand(this.RemoveStep);

        public bool CanRemoveStep => this.SelectedStep != null;

        public bool CanAddStep => this.SelectedStepContainer != null;

        public DelegateCommand ExportCommand => new DelegateCommand(this.Export);

        public DelegateCommand ImportCommand => new DelegateCommand(this.Import);

        protected void OnSelectedStepChanged(Step oldStep, Step newStep)
        {
            this.SelectedStepChanged?.Invoke(this, new SelectedStepChangedEventArgs(oldStep, newStep));
        }

        private void Export(object obj)
        {
            // TODO: Save the serialized data
            Trace.WriteLine(JsonExporter.Export(this.areas));
        }

        private void Import(object obj)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();

            var filePath = dialog.FileName;
            var json = System.IO.File.ReadAllText(filePath);

            this.Areas = new ObservableCollection<Area>(JsonExporter.Import(json));
        }

        private void AddStep(object obj)
        {
            var newStep = new Step(this.selectedStepContainer, "New Item");
            this.selectedStepContainer.Steps.Add(newStep);
        }

        private void RemoveStep(object obj)
        {
            var parent = this.selectedStep.Parent;
            parent.Steps.Remove(this.selectedStep);
        }

        private IEnumerable<Area> PopulateAreas()
        {
            return Constants.AreaNames.Select(areaName => new Area(areaName));
        }
    }
}