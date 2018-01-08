using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleAppEFCore2.Factory
{
    public class AdventureWorksContextScaffoldedFactory : IDesignTimeDbContextFactory<AdventureWorksContextDI>
    {
        public AdventureWorksContextDI CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AdventureWorksContextDI>();
            builder.UseSqlServer(@const.connectionStringGenerated);
            return new AdventureWorksContextDI(builder.Options);
        }
    }
}