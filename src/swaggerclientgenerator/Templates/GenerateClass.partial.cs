using System.Reflection.Emit;
using swaggerclientgenerator.GeneratorModels;
using swaggerclientgenerator.Schema;

namespace swaggerclientgenerator.Templates
{
    public partial class GenerateClass
    {
        private readonly ClassDefinition model;

        public GenerateClass(ClassDefinition model)
        {
            this.model = model;
        }
    }
}
