using System;
using Xunit;

namespace CLMS.CoursesContentManagement.Domain.Test
{
    public class FileContentTests
    {
        [Fact]
        public void Given_Create_When_BytesAreProvided_Then_ShouldCreateEntity()
        {
            // act
            var result = FileContent.Create(new byte[] { 0x00C9 });

            // assert
            Assert.NotNull(result);
        }
    }
}
