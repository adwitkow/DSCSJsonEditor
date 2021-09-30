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

using System.Windows;
using System.Windows.Controls;
using DSCSJsonEditor.Core.Models;
using DSCSJsonEditor.WPF.ViewModels;

namespace DSCSJsonEditor.WPF.Views
{
    /// <summary>
    /// Interaction logic for NavigationView.xaml.
    /// </summary>
    public partial class NavigationView : UserControl
    {
        public NavigationView()
        {
            this.InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.BindSelectedStep(e.NewValue);
            this.BindSelectedStepContainer(e.NewValue);
        }

        private void BindSelectedStepContainer(object obj)
        {
            // TODO: Access the ViewModel safely, without the cast
            if (obj is IStepContainer step)
            {
                ((NavigationViewModel)this.DataContext).SelectedStepContainer = step;
            }
            else
            {
                ((NavigationViewModel)this.DataContext).SelectedStepContainer = null;
            }
        }

        private void BindSelectedStep(object obj)
        {
            // TODO: Access the ViewModel safely, without the cast
            if (obj is Step step)
            {
                ((NavigationViewModel)this.DataContext).SelectedStep = step;
            }
            else
            {
                ((NavigationViewModel)this.DataContext).SelectedStep = null;
            }
        }
    }
}
