using Xunit;

namespace CLMS.CoursesContentManagement.Domain.Test
{
    public class FileTests
    {
        [Fact]
        public void Given_Create_When_DataIsProvided_Then_ShouldCreateEntity()
        {
            // arrange
            var fileContent = FileContent.Create(new byte[] {2});

            // act
            var result = File.Create("test", "jpg", fileContent);

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Given_Create_When_DataIsProvided_Then_ShouldSetFileContentId()
        {
            // arrange
            var fileContent = FileContent.Create(new byte[] { 2 });

            // act
            var result = File.Create("test", "jpg", fileContent);

            // assert
            Assert.Equal(fileContent.Id, result.FileContentId);
        }
    }
}