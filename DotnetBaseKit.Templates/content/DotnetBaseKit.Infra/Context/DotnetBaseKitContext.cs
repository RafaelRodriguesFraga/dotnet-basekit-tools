using BASEKIT_COMPONENTS_PACKAGE.Infra.Sql.Context.Base;
using BASEKIT_COMPONENTS_PACKAGE.Shared.Notifications;
using Microsoft.EntityFrameworkCore;

namespace DotnetBaseKit.Infra.Context;

public class DotnetBaseKitContext : BaseContext
{
    public DotnetBaseKitContext(DbContextOptions<DotnetBaseKitContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<Notification>();
    }
}
