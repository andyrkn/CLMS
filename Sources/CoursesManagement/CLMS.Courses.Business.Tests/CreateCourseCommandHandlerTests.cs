using System;
using System.Threading;
using CLMS.Courses.Domain;
using CLMS.Kernel;
using CSharpFunctionalExtensions;
using MediatR;
using Moq;
using Xunit;

namespace CLMS.Courses.Business.Tests
{
    public class CreateCourseCommandHandlerTests
    {
        private readonly Mock<ICourseHolderRespository> courseHolderRepositoryMock =
            new Mock<ICourseHolderRespository>();

        private readonly Mock<ICoursesRepository> courseReposiotryMock = new Mock<ICoursesRepository>();
        private readonly Mock<IDomainEventsDispatcher> eventsDispatcher = new Mock<IDomainEventsDispatcher>();
        private readonly string holderEmail = "test@email.com";
        private readonly string name = "test";

        [Fact]
        public void Given_Handle_When_CommandIsNull_Then_ShouldThrowException()
        {
            // act
            Action act = () => Handler().Handle(null, CancellationToken.None);

            // assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Given_Handle_When_CourseHolderIsNotFound_Then_ShouldReturnFailedResult()
        {
            // arrange
            courseHolderRepositoryMock.Setup(x => x.GetByEmail(holderEmail)).Returns(() => null);

            // act
            var result = Handler().Handle(Command(), CancellationToken.None).Result;

            // assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Given_Handle_When_CourseHolderIsFound_Then_ShouldReturnOkResult()
        {
            // arrange
            courseHolderRepositoryMock.Setup(x => x.GetByEmail(holderEmail)).Returns(CourseHolder.Create(holderEmail));

            // act
            var result = Handler().Handle(Command(), CancellationToken.None).Result;

            // assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Given_Handle_When_AfterContentIsCreated_Then_ShouldSaveToDatabase()
        {
            courseHolderRepositoryMock.Setup(x => x.GetByEmail(holderEmail)).Returns(CourseHolder.Create(holderEmail));

            // act
            var result = Handler().Handle(Command(), CancellationToken.None).Result;

            // assert
            courseReposiotryMock.Verify(x => x.Add(It.IsAny<Domain.Course>()));
            courseReposiotryMock.Verify(x => x.SaveChanges());
        }

        [Fact]
        public void Given_Handle_When_AfterContentIsCreated_Then_ShouldRaiseDomainEvent()
        {
            courseHolderRepositoryMock.Setup(x => x.GetByEmail(holderEmail)).Returns(CourseHolder.Create(holderEmail));

            // act
            var result = Handler().Handle(Command(), CancellationToken.None).Result;

            // assert
            eventsDispatcher.Verify(x => x.Raise(It.IsAny<CourseCreatedEvent>()));
        }

        private IRequestHandler<CreateCourseCommand, Result> Handler()
        {
            return new CreateCourseCommandHandler(courseReposiotryMock.Object, courseHolderRepositoryMock.Object,
                eventsDispatcher.Object);
        }

        private CreateCourseCommand Command()
        {
            return new CreateCourseCommand(new AddCourseModel {HolderEmail = holderEmail, Name = name});
        }
    }
}