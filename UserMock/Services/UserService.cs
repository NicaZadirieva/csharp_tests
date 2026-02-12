using System;
using System.Collections.Generic;
using System.Text;
using UserMock.Models;
using UserMock.Repositories;

namespace UserMock.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public string GetUserName(int id)
        {
            var user = _repo.GetById(id);
            return user?.name ?? "Unknown";
        }

        public User CreateUser(string name, string email, int age)
        {
            var user = new User(name, email, age);
            return _repo.Save(user);
        }
    }
}
