using Xunit;

namespace CLMS.Courses.Domain.Tests
{
    public class CourseTests
    {
        [Fact]
        public void Given_Create_When_DataIsProvided_Then_ShouldReturnEntity()
        {
            // act
            var result = Course.Create("test", CourseHolder.Create("test@email.com"));

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Given_Delete_Then_ShouldSetIsDeletedToTrue()
        {
            // arrange
            var course = Course.Create("test", CourseHolder.Create("test@email.com"));

            // act
            course.Delete();

            // assert
            Assert.True(course.IsDeleted);
        }
    }
}