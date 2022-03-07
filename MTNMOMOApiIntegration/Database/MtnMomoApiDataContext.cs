using Microsoft.EntityFrameworkCore;

namespace MTNMOMOApiIntegration.Database
{
    public class MtnMomoApiDataContext : DbContext
    {
        public MtnMomoApiDataContext(DbContextOptions<MtnMomoApiDataContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
