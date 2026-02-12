using System;
using System.Collections.Generic;
using System.Text;
using UserMock.Models;

namespace UserMock.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Получение юзера по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User? GetById(int id);

        /// <summary>
        /// Сохранение юзера в хранилище данных
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Юзер из хранилища данных</returns>
        User Save(string name, string email, int age);
    }
}
