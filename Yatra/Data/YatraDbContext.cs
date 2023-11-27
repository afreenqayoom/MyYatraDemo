using Microsoft.EntityFrameworkCore;
using Yatra.Models.Domain;

namespace Yatra.Data
{
    public class YatraDbContext : DbContext
    {
        public YatraDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Traveller> Travellers { get; set; }
    }
}
