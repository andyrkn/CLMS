using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using CLMS.Courses.Domain;
using MediatR;
using Moq;
using Xunit;

namespace CLMS.Courses.Business.Tests
{
    public class GetAllCoursesQueryHandlerTests
    {
        private readonly Mock<ICoursesRepository> coursesRepositoryMock = new Mock<ICoursesRepository>();
        private readonly Mock<IMapper> mapperMock = new Mock<IMapper>();

        private IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseModel>> Handler()
        {
            return new GetAllCoursesQueryHandler(coursesRepositoryMock.Object, mapperMock.Object);
        }

        private GetAllCoursesQuery Query()
        {
            return new GetAllCoursesQuery();
        }

        [Fact]
        public void Given_Handle_When_QueryIsNotNull_Then_ShouldRetrunModels()
        {
            // arrange
            coursesRepositoryMock.Setup(x => x.GetAll())
                .Returns(
                    new List<Domain.Course> {Domain.Course.Create("test", CourseHolder.Create("test"))}.AsQueryable());
            mapperMock.Setup(x => x.Map<IEnumerable<CourseModel>>(It.IsAny<IEnumerable<Domain.Course>>()))
                .Returns(new List<CourseModel> {new CourseModel()});

            // act
            var result = Handler().Handle(Query(), CancellationToken.None).Result;

            // assert
            Assert.True(result.Any());
        }

        [Fact]
        public void Given_Handle_When_QueryIsNull_Then_ShouldThrowException()
        {
            // act
            Action act = () => Handler().Handle(null, CancellationToken.None);

            // assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}