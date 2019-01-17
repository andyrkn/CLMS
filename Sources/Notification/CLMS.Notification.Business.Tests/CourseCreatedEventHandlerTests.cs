using System;
using CLMS.Notification.Domain.Entities;
using CLMS.Notification.Domain.Repository;
using Moq;
using Xunit;

namespace CLMS.Notification.Business.Tests
{
    public class CourseCreatedEventHandlerTests
    {
        private readonly Guid courseId = new Guid("8EA0601C-179A-43E1-B617-8D6A724E6A2B");
        private readonly string courseName = "test course";
        private readonly Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();

        [Fact]
        public void Given_Handle_When_EventIsNull_Then_ShouldThrowExecption()
        {
            // act
            Action act = () => Handler().Handle(null);

            // assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Given_Handle_When_EventIsNotNull_Then_ShouldCreateEventAndSaveChanges()
        {
            // act
            ExecuteEvent();

            // assert
            eventRepository.Verify(x  => x.Add(It.IsAny<Event>()));
            eventRepository.Verify(x => x.SaveChanges());
        }

        private void ExecuteEvent()
        {
            Handler().Handle(Event());
        }

        private CourseCreatedEventHandler Handler()
        {
            return new CourseCreatedEventHandler(eventRepository.Object);
        }

        private CourseCreatedEvent Event()
        {
            return new CourseCreatedEvent
            {
                Id = courseId,
                Name = courseName
            };
        }
    }
}
