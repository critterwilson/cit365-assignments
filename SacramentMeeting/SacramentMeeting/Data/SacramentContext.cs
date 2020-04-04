using Microsoft.EntityFrameworkCore;
using SacramentMeeting.Models;


namespace SacramentMeeting.Data
{
    public class SacramentContext : DbContext
    {
        public SacramentContext(DbContextOptions<SacramentContext> options)
            : base(options)
        {
        }

        public DbSet<Hymn> Hymn { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<SacramentMeeting.Models.Speaker> Speaker { get; set; }
    }
}
