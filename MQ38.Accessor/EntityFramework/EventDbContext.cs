using Microsoft.EntityFrameworkCore;
using MQ38.Accessor.EntityFramework.Models;

namespace MQ38.Accessor.EntityFramework
{
    public class EventDbContext : DbContext, IEventDbContext
    {
        public EventDbContext()
        {
        }

        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
    }
}