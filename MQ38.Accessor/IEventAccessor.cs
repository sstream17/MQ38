using System.Linq;
using MQ38.Accessor.EntityFramework.Models;

namespace MQ38.Accessor
{
    public interface IEventAccessor
    {
        IQueryable<Event> GetEventsQueryable();
    }
}