using System;
using CLMS.Courses.Business.Events;
using CLMS.Courses.Domain;
using Moq;
using Xunit;

namespace CLMS.Courses.Business.Tests
{
    public class UserRegisteredEventHandlerTests
    {
        private readonly Mock<ICourseHolderRespository> repositoryMock = new Mock<ICourseHolderRespository>();
        private readonly string email = "Email@test.t";

        [Fact]
        public void Given_Handle_When_EventIsNull_Then_ShouldThrowException()
        {
            // act
            Action act = () => Handler().Handle(null);

            // assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Given_Handle_When_EventRoleIsNotTeacher_Then_ShouldNotAddNewContentHolder()
        {
            // act
            Handler().Handle(UnknownEvent());

            // assert
            repositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void Given_Handle_When_EventRoleIsTeacher_Then_ShouldAddNewContentHolder()
        {
            // act
            Handler().Handle(TeacherEvent());

            // assert
            repositoryMock.Verify(x => x.Add(It.IsAny<CourseHolder>()));
            repositoryMock.Verify(x => x.SaveChanges());
        }

        private UserRegisteredEventHandler Handler()
        {
            return new UserRegisteredEventHandler(repositoryMock.Object);
        }

        private UserRegisteredEvent TeacherEvent()
        {
            return new UserRegisteredEvent {Email = email, Role = "Teacher"};
        }

        private UserRegisteredEvent UnknownEvent()
        {
            return new UserRegisteredEvent {Email = email, Role = "test"};
        }
    }
}