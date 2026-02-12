using System;
using System.Collections.Generic;
using System.Text;
using UserMock.Models;

namespace UserMock.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private IList<User> users = new List<User>();

        public User? GetById(int id)
        {
            return users.FirstOrDefault((u) => u?.dbId == id, null);
        }

        public User Save(string name, string email, int age)
        {
            int newDbId = 0;
            try
            {
                newDbId = users.Max(u => u.dbId) + 1;

            } catch (ArgumentNullException)
            {
                // список пуст
                newDbId = 0;
            }
            var newUser = new User(name, email, age, newDbId);
            users.Add(newUser);
            return newUser;
        }
    }
}
