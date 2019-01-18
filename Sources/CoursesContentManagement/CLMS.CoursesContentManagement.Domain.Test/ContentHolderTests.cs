using System;
using System.Collections.Generic;
using Xunit;

namespace CLMS.CoursesContentManagement.Domain.Test
{
    public class ContentHolderTests
    {
        private readonly string name = "test";
        private readonly string holderEmail = "test@email.com";
        private readonly Guid originId = new Guid("B74A4F9B-05D2-48DD-9ABC-16D8529B5DD3");

        [Fact]
        public void Given_Create_When_DataIsProvided_Then_ShouldCreateEntity()
        {
            // act
            var result = ContentHolder.Create(name, holderEmail, originId);

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Given_AddContent_When_ContentIsProvidedAndEmailIsNotForCurrentContent_Then_ShouldReturnFailedResult()
        {
            // arrange
            var content = Content.Create("test", new List<File>());
            var contentHolder = ContentHolder.Create(name, holderEmail, originId);
            // act

            var result = contentHolder.AddContent("noemail", content);

            // assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Given_AddContent_When_ContentIsProvidedAndEmailIsValid_Then_ShouldReturnOkResult()
        {
            // arrange
            var content = Content.Create("test", new List<File>());
            var contentHolder = ContentHolder.Create(name, holderEmail, originId);
            // act

            var result = contentHolder.AddContent(holderEmail, content);

            // assert
            Assert.True(result.IsSuccess);
        }
    }
}