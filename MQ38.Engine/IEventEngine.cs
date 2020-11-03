using System;
using System.Linq;
using MQ38.Accessor.EntityFramework.Models;

namespace MQ38.Engine
{
    public interface IEventEngine
    {
        IQueryable<Event> FilterByDate(
            IQueryable<Event> queryable,
            DateTime? startDate,
            DateTime? endDate);
    }
}