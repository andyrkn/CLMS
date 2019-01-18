using System.Collections.Generic;
using Xunit;

namespace CLMS.CoursesContentManagement.Domain.Test
{
    public class ContentTests
    {
        private readonly string description = "test description";

        [Fact]
        public void Given_Create_When_DescriptionAndFilesAreProvided_Then_ShouldCreateEntity()
        {
            // act
            var result = Content.Create(description, new List<File>());

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Given_Delete_Then_ShouldReturnOkResult()
        {
            // arrange
            var content = Content.Create(description, new List<File>());

            // act
            var result = content.Delete();

            // assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Given_Delete_Then_ShouldSetIsDeletedToTrue()
        {
            // arrange
            var content = Content.Create(description, new List<File>());

            // act
            content.Delete();

            // assert
            Assert.True(content.IsDeleted);
        }
    }
}