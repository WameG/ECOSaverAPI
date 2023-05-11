using ECOSaver.Models;
using Microsoft.EntityFrameworkCore;

namespace ECOSaver.Contexts
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {    
        }

        public DbSet<Weather> weathers { get; set; }
    }
}
