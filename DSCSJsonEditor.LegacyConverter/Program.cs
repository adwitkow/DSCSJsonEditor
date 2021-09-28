using DSCSJsonEditor.Core;
using DSCSJsonEditor.Core.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace DSCSJsonEditor.LegacyConverter
{
    class Program
    {
        static void Main(string[] args)
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
                
                var area = new Area(titleAnchor.InnerText.Trim());

                area.Name = id;
                area.Id = int.Parse(totalsId.Groups["Id"].Value); // TODO: Do this safely
                area.WikiUrl = titleAnchor.Attributes["href"].Value;

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
                var tagName = entityName.Replace("'", "");
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
