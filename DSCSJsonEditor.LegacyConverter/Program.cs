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
using System.Linq;
using System.Text.RegularExpressions;
using DSCSJsonEditor.Core;
using DSCSJsonEditor.Core.Models;
using HtmlAgilityPack;

namespace DSCSJsonEditor.LegacyConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var outputAreas = new List<Area>();

            var inputPath = args[0];
            var outputPath = args[1];

            var document = new HtmlDocument();
            document.Load(inputPath);

            var mainElement = document.GetElementbyId("playthrough_list");
            var areaHeaders = mainElement.Descendants("h3");

            foreach (var areaHeader in areaHeaders)
            {
                var id = areaHeader.Id;
                var text = areaHeader.InnerText.Trim();
                var listId = $"{id}_col";

                var span = areaHeader.Descendants("span").FirstOrDefault();
                var titleAnchor = areaHeader.Descendants("a")
                    .FirstOrDefault(node => !string.IsNullOrWhiteSpace(node.InnerText));

                var areaListElement = document.GetElementbyId(listId);
                var areaStepElements = areaListElement.ChildNodes.Where(node => node.Name == "li");

                var totalsId = Regex.Match(span.Id, @"playthrough_totals_(?<Id>\d+)");

                var area = new Area(titleAnchor.InnerText.Trim())
                {
                    Name = id,
                    Id = int.Parse(totalsId.Groups["Id"].Value), // TODO: Do this safely
                    WikiUrl = titleAnchor.Attributes["href"].Value,
                };

                foreach (var htmlStep in areaStepElements)
                {
                    var step = new Step(area);
                    var filters = htmlStep.GetClasses().Select(c => new Filter(c));
                    step.Filters = new ObservableCollection<Filter>(filters);

                    step.Entities = new ObservableCollection<Entity>(ParseEntities(htmlStep));
                    step.Description = htmlStep.InnerText;
                    area.Steps.Add(step);
                }

                outputAreas.Add(area);
            }

            System.IO.File.WriteAllText(outputPath, JsonExporter.Export(outputAreas));
        }

        private static IEnumerable<Entity> ParseEntities(HtmlNode node)
        {
            var entities = new List<Entity>();
            if (!node.HasChildNodes)
            {
                return entities;
            }

            var replacements = new Dictionary<HtmlNode, HtmlNode>();
            foreach (var childNode in node.ChildNodes)
            {
                if (childNode.Name != "a")
                {
                    continue;
                }

                var entityName = HtmlEntity.DeEntitize(childNode.InnerText.Trim());
                var tagName = entityName.Replace("'", string.Empty);
                tagName = Regex.Replace(tagName, @"\W", "-");
                tagName = $"@{tagName.ToLower()}";

                var entity = new Entity(tagName);
                entity.Details.Name = entityName;
                entity.Details.WikiUrl = childNode.Attributes["href"].Value;

                replacements.Add(HtmlNode.CreateNode(tagName), childNode);
                entities.Add(entity);
            }

            foreach (var replacementPair in replacements)
            {
                node.ReplaceChild(replacementPair.Key, replacementPair.Value);
            }

            return entities;
        }
    }
}
