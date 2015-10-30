using System.Collections.Generic;
using System.Linq;
using System.Text;
using swaggerclientgenerator.Schema;

namespace swaggerclientgenerator.GeneratorModels
{
    public class ClassDefinition
    {
        public ClassDefinition(string name,Definition definition)
        {
            type = definition.type;
            required = definition.required;
            Name = name;

            if (definition.AllOf != null && definition.AllOf.Any())
            {
                var subclasses = definition.AllOf.Select(x => x.Ref).ToArray();
            }

            PropertyInfos =
                (from propertyKvp in definition.Properties
                    let property = propertyKvp.Value
                    let propertyName = propertyKvp.Key
                    select new PropertyDefinition
                    {
                        Name = propertyName,
                        Attributes =
                            required.Any(x => x == propertyName) ? new[] {propertyName} : Enumerable.Empty<string>(),
                        Type = property.format ?? property.type
                    }).ToArray();
            ShouldGenerate = Name != "Object" && type == "object";

        }

        public string type { get; private set; }
        public string[] required { get; private set; }
        public string Name { get; }

        public bool ShouldGenerate { get; private set; }

        public IEnumerable<PropertyDefinition> PropertyInfos { get; }

        public string Render()
        {
            var sb = new StringBuilder($"public class {Name} {{\n");

            foreach (var x in PropertyInfos)
                sb.AppendLine("\t" + x.Render());

            sb.AppendLine($"}}");
            return sb.ToString();
        }
    }
}