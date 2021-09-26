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

namespace DSCSJsonEditor.Core.Models
{
    public class EntityDetails
    {
        public EntityDetails()
        {
            this.NewGamePlusEntity = new EntityDetails();
        }

        public string Name { get; set; }

        public string WikiUrl { get; set; }

        public EntityDetails NewGamePlusEntity { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return string.Empty;
            }

            return this.Name;
        }
    }
}