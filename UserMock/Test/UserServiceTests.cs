using FluentAssertions;
using Moq;
using UserMock.Models;
using UserMock.Repositories;
using UserMock.Services;

namespace UserMock.Test
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository;

        public UserServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
        }

        [Theory]
        [InlineData("Nica", "nica@gmail.com", 15)]
        [InlineData("Dim", "dim@gmail.com", 454)]
        [InlineData("Anton", "anton@gmail.com", 35)]
        public void GetUserName_ShouldReturnValidValues(string name, string email, int age)
        {
            // Arrange
            _userRepository.Setup(repo => repo.GetById(1))
                    .Returns(new User(name, email, age));

            var service = new UserService(_userRepository.Object);

            // Act
            var result = service.GetUserName(1);

            // Assert
            result.Should().NotBeNull()
                  .And.Be(name);                     // проверка имени

            _userRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [Theory]
        [InlineData("Nica", "nica@gmail.com", 15)]
        [InlineData("Dim", "dim@gmail.com", 454)]
        [InlineData("Anton", "anton@gmail.com", 35)]
        public void CreateUser_ShouldReturnValidValues(string name, string email, int age)
        {
            // Arrange
            var expectedUser = new User(name, email, age, 0);

            _userRepository.Setup(repo => repo.Save(name, email, age))
                    .Returns(expectedUser);

            var service = new UserService(_userRepository.Object);

            // Act
            var user = service.CreateUser(name, email, age);

            // Assert
            (name, email, age).Should().BeEquivalentTo((user.name, user.email, user.age));

            _userRepository.Verify(repo => repo.Save(name, email, age), Times.Once);
        }

        [Fact]
        public void GetUserName_ShouldReturnUnknown_WhenUserNotFound()
        {
            // Arrange
            _userRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                    .Returns((User)null);   // явно возвращаем null

            var service = new UserService(_userRepository.Object);

            // Act
            var result = service.GetUserName(99);

            // Assert
            result.Should().Be("Unknown");
            _userRepository.Verify(repo => repo.GetById(99), Times.Once);
        }
    }
}