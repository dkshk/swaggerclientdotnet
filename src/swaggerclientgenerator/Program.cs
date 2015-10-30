using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using swaggerclientgenerator.Schema;
using swaggerclientgenerator.Templates;

namespace swaggerclientgenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var file = @"Input\sample1.json";
            //file = @"Input\petstore-expanded.json";
            var contents = File.ReadAllText(file);
            var specification = JsonConvert.DeserializeObject<SwaggerSpecification>(contents);

            var endpoints = (from p in specification.Paths
                let path = p.Key
                from methodEndpoint in p.Value
                let method = methodEndpoint.Key
                let endpoint = methodEndpoint.Value
                select new FlattenedEndpoint
                {
                    Path = path,
                    Consumes = endpoint.Consumes,
                    Deprecated = endpoint.Deprecated,
                    OperationId = endpoint.OperationId,
                    Produces = endpoint.Produces,
                    Responses = endpoint.Responses,
                    Tags = endpoint.Tags
                }).ToList();


            var alphaNumericRegex = new Regex("[a-zA-Z]+");
            var classNameParts =
                alphaNumericRegex.Matches(specification.Host)
                    .Cast<Match>()
                    .Select(x => x.Value)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();

            var clientClassName =
                string.Join(string.Empty,
                    classNameParts.Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1).ToLower())) + "ApiClient";

            var templateModel = new SwaggerTemplateModel(clientClassName,"csn.core.clients", endpoints);
            var template = new BasicClientTemplate(templateModel);
            var code = template.TransformText();

            Console.WriteLine(code);
        }
    }
}
