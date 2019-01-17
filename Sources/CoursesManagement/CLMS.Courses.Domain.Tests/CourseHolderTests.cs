using Xunit;

namespace CLMS.Courses.Domain.Tests
{
    public class CourseHolderTests
    {
        [Fact]
        public void Given_Handle_When_EmailIsProvided_Then_ShouldReturnEntity()
        {
            // act
            var result = CourseHolder.Create("test@email.com");

            // assert
            Assert.NotNull(result);
        }
    }
}