using System;
using CLMS.CoursesContentManagement.Business.Events.ContentHolder;
using CLMS.CoursesContentManagement.Domain;
using Moq;
using Xunit;

namespace CLMS.CoursesContentManagement.Business.Test
{
    public class CourseCreateEventHandlerTests
    {
        private readonly Mock<IContentHolderRepository> contentHolderRepositoryMock =
            new Mock<IContentHolderRepository>();

        private readonly string holderEmail = "test@email.com";
        private readonly Guid holderId = new Guid("D365E2F8-15D2-4A82-9FF3-975805733E08");
        private readonly string holderName = "name";

        [Fact]
        public void Given_Handle_When_EventIsNull_Then_ShouldThrowException()
        {
            // act
            Action act = () => Handler().Handle(null);

            // assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Given_Handle_When_EventIsNotNul_Then_ShouldCreateContentHolder()
        {
            // act
            Handler().Handle(Event());

            // assert
            contentHolderRepositoryMock.Verify(x => x.Add(It.IsAny<Domain.ContentHolder>()));
            contentHolderRepositoryMock.Verify(x => x.SaveChanges());
        }

        private CourseCreatedEventHandler Handler()
        {
            return new CourseCreatedEventHandler(contentHolderRepositoryMock.Object);
        }

        private CourseCreatedEvent Event()
        {
            return new CourseCreatedEvent {HolderEmail = holderEmail, Id = holderId, Name = holderName};
        }
    }
}