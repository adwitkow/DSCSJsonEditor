using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCSJsonEditor.Core.Models
{
    public class Filter
    {
        public Filter(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
