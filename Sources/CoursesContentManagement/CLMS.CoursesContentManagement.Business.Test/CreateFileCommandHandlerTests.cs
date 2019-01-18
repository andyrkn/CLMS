using System;
using System.Threading;
using CLMS.CoursesContentManagement.Business.File.Create;
using CLMS.CoursesContentManagement.Domain;
using CSharpFunctionalExtensions;
using MediatR;
using Moq;
using Xunit;

namespace CLMS.CoursesContentManagement.Business.Test
{
    public class CreateFileCommandHandlerTests
    {
        private readonly Mock<IFileRepository> fileRepositoryMock = new Mock<IFileRepository>();

        [Fact]
        public void Given_Handle_When_CommandIsNull_Then_ShouldThrowException()
        {
            // act
            Action action = () => Handler().Handle(null, CancellationToken.None);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Given_Handle_When_CommandIsNotNull_Then_ShouldCreateFile()
        {
            // act
            var result = Handler().Handle(Command(), CancellationToken.None).Result;

            // assert
            fileRepositoryMock.Verify(x => x.Add(It.IsAny<Domain.File>()));
            fileRepositoryMock.Verify(x => x.SaveChanges());
        }

        private IRequestHandler<CreateFileCommand, Result<string>> Handler()
        {
            return new CreateFileCommandHandler(fileRepositoryMock.Object);
        }

        private CreateFileCommand Command()
        {
            return new CreateFileCommand("test.jpg", "jpg", new byte[] {0});
        }
    }
}