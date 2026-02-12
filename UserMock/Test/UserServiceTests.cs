using FluentAssertions;
using Moq;
using UserMock.Models;
using UserMock.Repositories;
using UserMock.Services;

namespace UserMock.Test
{
    public class UserServiceTests
    {
        [Theory]
        [InlineData("Nica", "nica@gmail.com", 15)]
        [InlineData("Dim", "dim@gmail.com", 454)]
        [InlineData("Anton", "anton@gmail.com", 35)]
        public void GetUserName_ShouldReturnValidValues(string name, string email, int age)
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetById(1))
                    .Returns(new User(name, email, age));

            var service = new UserService(mockRepo.Object);

            // Act
            var result = service.GetUserName(1);

            // Assert
            result.Should().NotBeNull()
                  .And.Be(name);                     // проверка имени

            mockRepo.Verify(repo => repo.GetById(1), Times.Once);
        }

        [Theory]
        [InlineData("Nica", "nica@gmail.com", 15)]
        [InlineData("Dim", "dim@gmail.com", 454)]
        [InlineData("Anton", "anton@gmail.com", 35)]
        public void CreateUser_ShouldReturnValidValues(string name, string email, int age)
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var expectedUser = new User(name, email, age, 0);

            mockRepo.Setup(repo => repo.Save(name, email, age))
                    .Returns(expectedUser);

            var service = new UserService(mockRepo.Object);

            // Act
            var user = service.CreateUser(name, email, age);

            // Assert
            (name, email, age).Should().BeEquivalentTo((user.name, user.email, user.age));

            mockRepo.Verify(repo => repo.Save(name, email, age), Times.Once);
        }

        [Fact]
        public void GetUserName_ShouldReturnUnknown_WhenUserNotFound()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetById(It.IsAny<int>()))
                    .Returns((User)null);   // явно возвращаем null

            var service = new UserService(mockRepo.Object);

            // Act
            var result = service.GetUserName(99);

            // Assert
            result.Should().Be("Unknown");
            mockRepo.Verify(repo => repo.GetById(99), Times.Once);
        }
    }
}