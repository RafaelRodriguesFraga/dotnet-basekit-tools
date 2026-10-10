using BASEKIT_COMPONENTS_PACKAGE.Infra.Sql.Context.Base;
using BASEKIT_COMPONENTS_PACKAGE.Infra.Sql.Repositories.Base;
using DotnetBaseKit.Domain.Entities;
using DotnetBaseKit.Domain.Repositories;

namespace DotnetBaseKit.Infra.Repositories;

public class ExampleWriteRepository : BaseWriteRepository<Example>, IExampleWriteRepository
{
    public ExampleWriteRepository(BaseContext context) : base(context)
    {
    }
}