using System.Collections.Generic;

namespace swaggerclientgenerator.Schema
{
    public static class SwaggerSchemaHelpers
    {
        public static Dictionary<string, string> SwaggerToCsharpTypeMap = new Dictionary<string, string>
        {
            {"string", "string"},
            {"integer", "int"},
            {"int32", "int"},
            {"date-time", "DateTime"}
        };

        public static string ToCsharpType(this string swaggerType)
            => SwaggerToCsharpTypeMap.ContainsKey(swaggerType) ? SwaggerToCsharpTypeMap[swaggerType] : swaggerType;
    }
}