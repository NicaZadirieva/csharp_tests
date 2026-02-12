using FluentAssertions;
using Moq;
using System.Xml.Linq;
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
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(repo => repo.GetById(1))
                    .Returns(new User(name, email, age));

            var service = new UserService(mockRepo.Object);
            service.GetUserName(1).Should().Be(name);
            mockRepo.Verify(repo => repo.GetById(1), Times.Once);
        }

        [Theory]
        [InlineData("Nica", "nica@gmail.com", 15)]
        [InlineData("Dim", "dim@gmail.com", 454)]
        [InlineData("Anton", "anton@gmail.com", 35)]
        public void CreateUser_ShouldReturnValidValues(string name, string email, int age)
        {
            var mockRepo = new Mock<IUserRepository>();
            var testUser = new User(name, email, age, 0);
            mockRepo.Setup(repo => repo.Save(name, email, age))
                    .Returns(testUser);

            var service = new UserService(mockRepo.Object);
            var result = service.CreateUser(name, email, age);
            result.name.Should().Be(name);
            result.email.Should().Be(email);
            result.age.Should().Be(age);
            mockRepo.Verify(repo => repo.Save(name, email, age), Times.Once);
        }

        [Fact]
        public void GetUserName_ShouldReturnUnknown()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);
            service.GetUserName(1).Should().Be("Unknown");
            mockRepo.Verify(repo => repo.GetById(1), Times.Once);
        }
    }
}
