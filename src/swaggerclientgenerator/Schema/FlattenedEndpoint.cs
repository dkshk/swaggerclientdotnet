using System.Collections.Generic;

namespace swaggerclientgenerator.Schema
{
    public class FlattenedEndpoint
    {
        public string Path { get; set; }
        public string[] Tags { get; set; }
        public string OperationId { get; set; }
        public object[] Consumes { get; set; }
        public string[] Produces { get; set; }
        public Dictionary<string, Response> Responses { get; set; }
        public bool Deprecated { get; set; }
    }
}