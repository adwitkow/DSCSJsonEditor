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

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DSCSJsonEditor.Core.Models
{
    public class Area : IStepContainer
    {
        public Area(string displayName)
        {
            this.DisplayName = displayName;

            this.Steps = new ObservableCollection<Step>();
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string WikiUrl { get; set; }
        public int Id { get; set; }

        public ObservableCollection<Step> Steps { get; set; }
    }
}
