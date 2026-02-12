using System;
using System.Collections.Generic;
using System.Text;

namespace UserMock.Models
{
    public class User
    {
        public string name { get; }
        public string email { get; }
        public int age { get; }
        public int dbId { get; set; } = -1;

        public User(string name, string email, int age, int dbId = -1)
        {
            this.name = name;
            this.email = email;
            this.age = age;
            this.dbId = dbId;
        }
    }
}
