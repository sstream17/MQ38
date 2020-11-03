using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MQ38.Shared;

namespace MQ38.Manager
{
    public interface IEventManager
    {
        Task<List<WeatherForecast>> GetEventDatas(DateTime? startDate, DateTime? endDate);
    }
}