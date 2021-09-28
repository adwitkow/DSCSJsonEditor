using DSCSJsonEditor.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCSJsonEditor.Core
{
    public static class JsonExporter
    {
        public static string Export(IEnumerable<Area> areas)
        {
            var serializer = CreateSerializer();

            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, areas);
                return textWriter.ToString();
            }
        }

        public static IEnumerable<Area> Import(string json)
        {
            var serializer = CreateSerializer();

            var reader = new JsonTextReader(new StringReader(json));

            return serializer.Deserialize<IEnumerable<Area>>(reader);
        }

        private static JsonSerializer CreateSerializer()
        {

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };

            var serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = contractResolver,
            };

            serializer.Converters.Add(new FilterConverter());

            return serializer;
        }

        private class FilterConverter : JsonConverter<Filter>
        {
            public override void WriteJson(JsonWriter writer, Filter value, JsonSerializer serializer)
            {
                writer.WriteValue(value.Name);
            }

            public override Filter ReadJson(JsonReader reader, Type objectType, Filter existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                string s = (string)reader.Value;

                return new Filter(s);
            }
        }
    }
}
