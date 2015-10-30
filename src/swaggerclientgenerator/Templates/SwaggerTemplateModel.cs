using System.Collections.Generic;
using swaggerclientgenerator.GeneratorModels;
using swaggerclientgenerator.Schema;

namespace swaggerclientgenerator.Templates
{
    public class SwaggerTemplateModel
    {
        public SwaggerTemplateModel(string className,string @namespace, IEnumerable<FlattenedEndpoint> endpoints,IEnumerable<ClassDefinition> definitions)
        {
            Namespace = @namespace;
            ClassName = className;
            Endpoints = endpoints;
            Definitions = definitions;
        }

        public string ClassName { get; }
        public IEnumerable<FlattenedEndpoint> Endpoints { get; }
        public IEnumerable<ClassDefinition> Definitions { get; }
        public string Namespace { get; }
    }
}
