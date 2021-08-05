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
using DSCSJsonEditor.Models;

namespace DSCSJsonEditor.ViewModels
{
    public class EditEntityViewModel : IEditableObject
    {
        private EntityDetails rollback;

        public EditEntityViewModel(EntityDetails entity)
        {
            this.EntityDetails = entity;
        }

        public EntityDetails EntityDetails { get; set; }

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
            this.CopyProperties(this.rollback, this.EntityDetails);
        }

        public void EndEdit()
        {
            // Uhh, do nothing?
        }

        private void CopyProperties(EntityDetails from, EntityDetails to)
        {
            to.Name = from.Name;
            to.WikiUrl = from.WikiUrl;
        }
    }
}
