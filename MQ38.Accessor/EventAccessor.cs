using System.Linq;
using MQ38.Accessor.EntityFramework;
using MQ38.Accessor.EntityFramework.Models;

namespace MQ38.Accessor
{
    public class EventAccessor : IEventAccessor
    {
        public EventAccessor(IEventDbContext eventDbContext)
        {
            EventDbContext = eventDbContext;
        }

        private IEventDbContext EventDbContext { get; }

        public IQueryable<Event> GetEventsQueryable()
        {
            try
            {
                return EventDbContext
                    .Events
                    .AsQueryable();
            }
            catch
            {
                throw;
            }
        }
    }
}
