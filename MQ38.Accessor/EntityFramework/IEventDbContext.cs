using Microsoft.EntityFrameworkCore;
using MQ38.Accessor.EntityFramework.Models;

namespace MQ38.Accessor.EntityFramework
{
    public interface IEventDbContext
    {
        DbSet<Event> Events { get; set; }

        int SaveChanges();
    }
}
