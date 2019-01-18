using System;
using System.Collections.Generic;
using System.Threading;
using CLMS.CoursesContentManagement.Domain;
using CLMS.Kernel;
using CSharpFunctionalExtensions;
using MediatR;
using Moq;
using Xunit;

namespace CLMS.CoursesContentManagement.Business.Test
{
    public class AddContentCommandHandlerTests
    {
        private readonly string holderEmail = "test@email.com";
        private readonly Guid contentHolderId = new Guid("0C2F714B-E870-4058-9C29-ED29125D64FD");

        private readonly Mock<IContentHolderRepository> contentHolderRepositoryMock =
            new Mock<IContentHolderRepository>();

        private readonly Mock<IDomainEventsDispatcher> eventsDispatcherMock = new Mock<IDomainEventsDispatcher>();
        private readonly Mock<IFileRepository> fileRepositoryMock = new Mock<IFileRepository>();

        private IRequestHandler<AddContentCommand, Result> Handler()
        {
            return new AddContentCommandHandler(fileRepositoryMock.Object, contentHolderRepositoryMock.Object,
                eventsDispatcherMock.Object);
        }

        private AddContentCommand Command()
        {
            return new AddContentCommand(
                new AddContentModel {FilesIds = new List<Guid>(), Description = "test", Email = holderEmail},
                contentHolderId);
        }

        [Fact]
        public void Given_Handle_When_CommandIsNull_Then_ShouldThrowExcepiton()
        {
            // act
            Action act = () => Handler().Handle(null, CancellationToken.None);

            // assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Given_Handle_When_ContentHolderIsFound_Then_ShouldReturnOkResult()
        {
            // arrange
            var contentHolder = Domain.ContentHolder.Create("test", holderEmail, contentHolderId);
            contentHolderRepositoryMock.Setup(x => x.GetById(contentHolderId)).Returns(contentHolder);

            // act
            var result = Handler().Handle(Command(), CancellationToken.None).Result;

            // assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Given_Handle_When_ContentHolderIsNotFound_Then_ShouldReturnFailedResult()
        {
            // arrange
            contentHolderRepositoryMock.Setup(x => x.GetById(contentHolderId)).Returns(() => null);

            // act
            var result = Handler().Handle(Command(), CancellationToken.None).Result;

            // assert
            Assert.True(result.IsFailure);
        }
    }
}