using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Moq;
using MQ38.Accessor;
using MQ38.Accessor.EntityFramework.Models;
using MQ38.Engine;
using MQ38.Manager;
using MQ38.Shared;
using Xunit;

namespace MQ38.Tests
{
    public class EventManagerTests
    {
        private List<Event> Events
        {
            get
            {
                return GetTestEvents();
            }
        }

        [Fact]
        public void GetEventDatas_DefaultFilterOptions_ReturnsAllEvents()
        {
            // Arrange
            var expectedEvents = new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Date = new DateTime(2020, 1, 1),
                    TemperatureC = 21,
                    Summary = "summary"
                },
                new WeatherForecast
                {
                    Date = new DateTime(2020, 2, 1),
                    TemperatureC = 23,
                    Summary = "summary"
                },
                new WeatherForecast
                {
                    Date = new DateTime(2020, 3, 1),
                    TemperatureC = 25,
                    Summary = "summary"
                },
                new WeatherForecast
                {
                    Date = new DateTime(2020, 4, 1),
                    TemperatureC = 27,
                    Summary = "summary"
                }
            };

            var mockAccessor = new Mock<IEventAccessor>();
            mockAccessor
                .Setup(m => m.GetEventsQueryable())
                .Returns(Events.AsQueryable());

            var mockEngine = new Mock<IEventEngine>();
            mockEngine
                .Setup(m => m.FilterByDate(It.IsAny<IQueryable<Event>>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(Events.AsQueryable());

            var eventManager = new EventManager(mockEngine.Object, mockAccessor.Object);

            // Act
            var actualEvents = eventManager.GetEventDatas(null, null);

            // Assert
            // Serializing as JSON so the objects can be directly compared
            var serializedEvents = JsonSerializer.Serialize(actualEvents);
            var expectedSerializedEvents = JsonSerializer.Serialize(expectedEvents);
            Assert.Equal(expectedSerializedEvents, serializedEvents);
        }

        private List<Event> GetTestEvents()
        {
            return new List<Event>
            {
                new Event
                {
                    Date = new DateTime(2020, 1, 1),
                    TemperatureC = 21,
                    Summary = "summary"
                },
                new Event
                {
                    Date = new DateTime(2020, 2, 1),
                    TemperatureC = 23,
                    Summary = "summary"
                },
                new Event
                {
                    Date = new DateTime(2020, 3, 1),
                    TemperatureC = 25,
                    Summary = "summary"
                },
                new Event
                {
                    Date = new DateTime(2020, 4, 1),
                    TemperatureC = 27,
                    Summary = "summary"
                }
            };
        }
    }
}
