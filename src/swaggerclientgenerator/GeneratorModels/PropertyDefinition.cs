using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace swaggerclientgenerator.Schema
{
    public class PropertyDefinition
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> Attributes { get; set; }

        public string RenderAttributes()
            => Attributes?.Any() ?? false ? $"{string.Join(",", Attributes)}" : string.Empty;

        public string Render() => $"{Type.ToCsharpType()}   {Name} {{ get;set }}";
    }
}