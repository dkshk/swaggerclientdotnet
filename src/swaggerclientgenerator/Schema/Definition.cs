using System.Collections.Generic;

namespace swaggerclientgenerator.Schema
{
    public class Definition
    {
        public string type { get; set; }
        public string[] required { get; set; }
        public Dictionary<string, Property> Properties { get; set; }

        public AllOfRef[] AllOf  { get; set; }
    }
    
    public class AllOfRef
    {
        public string Ref { get; set; }
    }
}