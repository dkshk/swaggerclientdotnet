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


    public class Definition
    {
        public string type { get; set; }
        public string[] required { get; set; }
        public Dictionary<string, Property> Properties { get; set; }
    }
    
    public class Property
    {
        public string format { get; set; }
        public int maximum { get; set; }
        public int minimum { get; set; }
        public string type { get; set; }
    }

    public class Name
    {
        public string type { get; set; }
    }

    public class Tag
    {
        public string type { get; set; }
    }

}