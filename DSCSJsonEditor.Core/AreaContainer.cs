using DSCSJsonEditor.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCSJsonEditor.Core
{
    public class AreaContainer
    {
        public AreaContainer()
        {
            this.Areas = new ObservableCollection<Area>(this.PopulateAreas());
        }

        public ObservableCollection<Area> Areas { get; set; }

        private IEnumerable<Area> PopulateAreas()
        {
            return Constants.AreaNames.Select(areaName => new Area(areaName));
        }
    }
}
