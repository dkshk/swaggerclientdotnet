namespace swaggerclientgenerator.Templates
{
    public partial class BasicClientTemplate
    {
        private readonly SwaggerTemplateModel model;

        public BasicClientTemplate() : this(null)
        {
            
        }

        public BasicClientTemplate(SwaggerTemplateModel model)
        {
            this.model = model;
        }
    }
}
