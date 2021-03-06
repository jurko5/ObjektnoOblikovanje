﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace DataRepository.Repositories.InvoiceRepository
{
    public interface IUserRepository
    {

        void Create(User user);
        User GetById(int id);

        User GetUserByCredentials(UserCredentials userCredentials);
        void UpdateUser(User user);

        void DeleteUser(User user);
    }
}
