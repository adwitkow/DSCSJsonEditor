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

using DSCSJsonEditor.Core.Models;

namespace DSCSJsonEditor.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private NavigationViewModel navigationViewModel;
        private EditStepViewModel editStepViewModel;
        private EditAreaViewModel editAreaViewModel;

        private ViewModelBase editViewModel;

        public MainWindowViewModel(NavigationViewModel navigationViewModel, EditStepViewModel editStepViewModel, EditAreaViewModel editAreaViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
            this.EditStepViewModel = editStepViewModel;
            this.EditAreaViewModel = editAreaViewModel;

            this.EditViewModel = editStepViewModel;

            this.navigationViewModel.SelectedStepContainerChanged += this.NavigationViewModel_SelectedStepContainerChanged;
        }

        public NavigationViewModel NavigationViewModel
        {
            get => this.navigationViewModel;
            set
            {
                this.SetProperty(ref this.navigationViewModel, value);
            }
        }

        public EditStepViewModel EditStepViewModel
        {
            get => this.editStepViewModel;
            set
            {
                this.SetProperty(ref this.editStepViewModel, value);
            }
        }

        public EditAreaViewModel EditAreaViewModel
        {
            get => this.editAreaViewModel;
            set
            {
                this.SetProperty(ref this.editAreaViewModel, value);
            }
        }

        public ViewModelBase EditViewModel
        {
            get => this.editViewModel;
            set
            {
                this.SetProperty(ref this.editViewModel, value);
            }
        }

        private void NavigationViewModel_SelectedStepContainerChanged(object sender, Events.SelectedStepContainerChangedEventArgs e)
        {
            this.editStepViewModel.SelectedStep = e.NewStepContainer as Step;

            if (e.NewStepContainer is Area)
            {
                this.EditViewModel = this.editAreaViewModel;
            }
            else
            {
                this.EditViewModel = this.editStepViewModel;
            }
        }
    }
}
