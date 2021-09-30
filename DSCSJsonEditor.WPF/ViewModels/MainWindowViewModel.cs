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
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DSCSJsonEditor.Core;
using DSCSJsonEditor.Core.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DSCSJsonEditor.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private NavigationViewModel navigationViewModel;
        private EditStepViewModel editStepViewModel;

        public MainWindowViewModel(NavigationViewModel navigationViewModel, EditStepViewModel editStepViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
            this.EditStepViewModel = editStepViewModel;

            this.navigationViewModel.SelectedStepChanged += editStepViewModel.SelectedStepChanged;
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
    }
}
