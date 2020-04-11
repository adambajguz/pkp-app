using TrainsOnline.Persistence.Infrastructure;

namespace TrainsOnline.Persistence
{
    using Persistence.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public class PKPAppDbContextFactory : DesignTimeDbContextFactoryBase<PKPAppDbContext>
    {
        protected override PKPAppDbContext CreateNewInstance(DbContextOptions<PKPAppDbContext> options)
        {
            return new PKPAppDbContext(options);
        }
    }
}
