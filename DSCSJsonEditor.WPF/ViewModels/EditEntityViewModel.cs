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

using System.ComponentModel;
using System.Runtime.CompilerServices;
using DSCSJsonEditor.Core.Models;

namespace DSCSJsonEditor.WPF.ViewModels
{
    public class EditEntityViewModel : INotifyPropertyChanged
    {
        private EntityDetails rollback;
        private EntityDetails entityDetails;

        public EditEntityViewModel(EntityDetails entity)
        {
            this.EntityDetails = entity;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => this.EntityDetails.Name;
            set
            {
                this.EntityDetails.Name = value;
                this.NotifyPropertyChanged();
            }
        }

        public string WikiUrl
        {
            get => this.EntityDetails.WikiUrl;
            set
            {
                this.EntityDetails.WikiUrl = value;
                this.NotifyPropertyChanged();
            }
        }

        public EntityDetails NewGamePlusEntity
        {
            get => this.EntityDetails.NewGamePlusEntity;
            set
            {
                this.EntityDetails.NewGamePlusEntity = value;
                this.NotifyPropertyChanged();
            }
        }

        public EntityDetails EntityDetails
        {
            get => this.entityDetails;
            set
            {
                this.entityDetails = value;
                this.NotifyPropertyChanged();
            }
        }

        public void BeginEdit()
        {
            if (this.rollback is null)
            {
                this.rollback = new EntityDetails();
            }

            this.CopyProperties(this.EntityDetails, this.rollback);

            if (this.EntityDetails.NewGamePlusEntity != null)
            {
                this.rollback.NewGamePlusEntity = new EntityDetails();

                this.CopyProperties(this.EntityDetails.NewGamePlusEntity, this.rollback.NewGamePlusEntity);
            }
        }

        public void CancelEdit()
        {
            this.CopyProperties(this.rollback, this.EntityDetails, true);
        }

        public void EndEdit()
        {
            this.rollback = new EntityDetails();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CopyProperties(EntityDetails from, EntityDetails to, bool notify = false)
        {
            to.Name = from.Name;
            to.WikiUrl = from.WikiUrl;

            if (notify)
            {
                this.NotifyPropertyChanged(nameof(this.Name));
                this.NotifyPropertyChanged(nameof(this.WikiUrl));
            }
        }
    }
}
