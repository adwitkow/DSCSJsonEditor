using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCSJsonEditor.LegacyConverter.HtmlModel
{
    class HtmlArea
    {
        public HtmlArea(string id, string name)
        {
            this.Name = name;
            this.Id = id;
            this.ListId = $"{id}_col";
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public string ListId { get; set; }
    }
}
