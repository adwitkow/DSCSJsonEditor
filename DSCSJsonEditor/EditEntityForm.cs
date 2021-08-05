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

using System.Windows.Forms;
using DSCSJsonEditor.Models;
using DSCSJsonEditor.ViewModels;

namespace DSCSJsonEditor
{
    public partial class EditEntityForm : Form
    {
        private bool saving;

        public EditEntityForm()
        {
            this.InitializeComponent();
        }

        public EditEntityViewModel ViewModel { get; set; }

        public void ShowFor(IWin32Window owner, Entity model)
        {
            // TODO: This if block is really awkward,
            // I guess the EditEntityViewModel should allow for an empty constructor
            if (this.ViewModel is null)
            {
                this.ViewModel = new EditEntityViewModel(model.Details);
            }
            else
            {
                this.ViewModel.EntityDetails = model.Details;
            }

            this.editEntityViewModelBindingSource.DataSource = this.ViewModel;

            this.ViewModel.BeginEdit();
            this.ShowDialog(owner);
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            this.saving = true;

            this.ViewModel.EndEdit();
            this.Close();

            this.saving = false;
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            this.ViewModel.CancelEdit();
            this.Close();
        }

        private void EditEntityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.saving)
            {
                this.ViewModel.CancelEdit();
            }
        }
    }
}
