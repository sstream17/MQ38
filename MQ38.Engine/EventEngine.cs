using System;
using System.Linq;
using MQ38.Accessor.EntityFramework.Models;

namespace MQ38.Engine
{
    public class EventEngine : IEventEngine
    {
        public IQueryable<Event> FilterByDate(
            IQueryable<Event> queryable,
            DateTime? startDate,
            DateTime? endDate)
        {
            if (startDate != null)
            {
                queryable = queryable.Where(e => e.Date >= startDate);
            }

            if (endDate != null)
            {
                queryable = queryable = queryable.Where(e => e.Date <= endDate);
            }

            return queryable;
        }
    }
}
