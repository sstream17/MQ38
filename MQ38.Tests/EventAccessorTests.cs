using System;
using System.Collections.Generic;
using System.Linq;
using MockQueryable.Moq;
using Moq;
using MQ38.Accessor;
using MQ38.Accessor.EntityFramework;
using MQ38.Accessor.EntityFramework.Models;
using Xunit;

namespace MQ38.Tests
{
    public class EventAccessorTests
    {
        private List<Event> Events
        {
            get
            {
                return new List<Event>
                {
                    new Event
                    {
                        Date = new DateTime(2020, 11, 3),
                        TemperatureC = 21,
                        Summary = "Event summary"
                    }
                };
            }
        }

        [Fact]
        public void Get_ReturnsEventDataQueryable()
        {
            // Arrange
            var mockDbSet = Events.AsQueryable().BuildMockDbSet();
            var mockDbContext = new Mock<IEventDbContext>();
            mockDbContext
                .Setup(db => db.Events)
                .Returns(mockDbSet.Object);

            var eventAccessor = new EventAccessor(mockDbContext.Object);

            // Act
            var actualQueryable = eventAccessor.GetEventsQueryable();

            // Assert
            Assert.NotNull(actualQueryable);
            Assert.IsAssignableFrom<IQueryable<Event>>(actualQueryable);
        }
    }
}

