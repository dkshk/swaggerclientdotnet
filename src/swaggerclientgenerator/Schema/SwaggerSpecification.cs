using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace swaggerclientgenerator.Schema
{
    public class SwaggerSpecification
    {
        public string Swagger { get; set; }
        public SwaggerSpecificationInfo Info { get; set; }

        public string Host { get; set; }

        public string[] Schemes { get; set; }

        public Dictionary<string, Dictionary<string, Endpoint>> Paths { get; set; }

        public Dictionary<string,Definition> Definitions { get; set; } 
    }
}