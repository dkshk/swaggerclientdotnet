using System.Collections.Generic;
using swaggerclientgenerator.Schema;

namespace swaggerclientgenerator.Templates
{
    public class SwaggerTemplateModel
    {
        public SwaggerTemplateModel(string className,string @namespace, IEnumerable<FlattenedEndpoint> endpoints)
        {
            Namespace = @namespace;
            ClassName = className;
            Endpoints = endpoints;
        }

        public string ClassName { get; }
        public IEnumerable<FlattenedEndpoint> Endpoints { get; }
        public string Namespace { get; }
    }
}
