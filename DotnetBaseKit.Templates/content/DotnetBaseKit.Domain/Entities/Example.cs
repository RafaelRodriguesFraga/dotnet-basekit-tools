using BASEKIT_COMPONENTS_PACKAGE.Domain.Sql.Entities.Base;

namespace DotnetBaseKit.Domain.Entities
{
    public class Example : BaseEntity
    {

        public string ExampleProperty { get; set; } = string.Empty;

        public Example(string exampleProperty)
        {
            ExampleProperty = exampleProperty;
        }

        public override void Validate()
        {
        }
    }
}