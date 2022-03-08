using Microsoft.EntityFrameworkCore;
using MTNMOMOApiIntegration.Model;

namespace MTNMOMOApiIntegration.Database
{
    public class MtnMomoApiDataContext : DbContext
    {
        public MtnMomoApiDataContext(DbContextOptions<MtnMomoApiDataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<MtnMomoApiRequest> MtnMomoApiRequest { get; set; }
    }
}
