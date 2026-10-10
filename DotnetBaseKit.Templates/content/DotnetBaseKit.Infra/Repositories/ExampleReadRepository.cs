using BASEKIT_COMPONENTS_PACKAGE.Infra.Sql.Context.Base;
using BASEKIT_COMPONENTS_PACKAGE.Infra.Sql.Repositories.Base;
using DotnetBaseKit.Domain.Entities;
using DotnetBaseKit.Domain.Repositories;

namespace DotnetBaseKit.Infra.Repositories;

public class ExampleReadRepository : BaseReadRepository<Example>, IExampleReadRepository
{
    public ExampleReadRepository(BaseContext context) : base(context)
    {
    }
}