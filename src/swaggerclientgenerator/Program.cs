using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using swaggerclientgenerator.GeneratorModels;
using swaggerclientgenerator.Schema;
using swaggerclientgenerator.Templates;

namespace swaggerclientgenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var files = new Dictionary<string, string>
            {
                {@"Input\sample1.json", string.Empty},
                {@"Input\petstore-expanded.json", string.Empty},
            };


            foreach (var file in files.Keys.ToList())
            {
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
                        classNameParts.Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1).ToLower())) +
                    "ApiClient";

                var templateModel = new SwaggerTemplateModel(
                    clientClassName,
                    "csn.core.clients",
                    endpoints, specification.Definitions.Select(x => new ClassDefinition(x.Key, x.Value)));

                var template = new BasicClientTemplate(templateModel);
                files[file] = template.TransformText();
            }

            var code = string.Join(Environment.NewLine + "/********************/" +Environment.NewLine, files.Values);

            Console.WriteLine(code);
        }
    }
}
