using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MQ38.Accessor;
using MQ38.Engine;
using MQ38.Shared;

namespace MQ38.Manager
{
    public class EventManager : IEventManager
    {
        public EventManager(IEventEngine eventEngine, IEventAccessor eventAccessor)
        {
            EventEngine = eventEngine;
            EventAccessor = eventAccessor;
        }

        private IEventEngine EventEngine { get; }

        private IEventAccessor EventAccessor { get; }

        public async Task<List<WeatherForecast>> GetEventDatas(DateTime? startDate, DateTime? endDate)
        {
            var queryable = EventAccessor.GetEventsQueryable();

            queryable = EventEngine.FilterByDate(queryable, startDate, endDate);

            var eventDatas = await queryable
                .ToListAsync()
                .ConfigureAwait(false);

            // In the actual application, I use AutoMapper to map between the EF model and the client class
            var weatherForecasts = new List<WeatherForecast>();
            eventDatas.ForEach(e =>
            {
                weatherForecasts.Add(new WeatherForecast
                {
                    Date = e.Date,
                    TemperatureC = e.TemperatureC,
                    Summary = e.Summary
                });
            });

            return weatherForecasts;
        }
    }
}
