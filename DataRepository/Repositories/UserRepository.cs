﻿using System.Linq;
using DataRepository.Models;
using DataRepository.nHibernateDb;
using DataRepository.Repositories.InvoiceRepository;
using NHibernate;
using NHibernate.Criterion;

namespace DataRepository.Repositories
{
    public class UserRepository : IUserRepository
    {

        private ISessionFactory sessionFactory;
        public UserRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }
        public UserRepository()
        {
            this.sessionFactory = SessionManager.SessionFactory;
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        public void Create(User user)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(user);
                    transaction.Commit();
                    //MessageBox.Show("Created user: " + user.Username);
                }

            }
        }

        public User GetById(int id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    User user = session.Get<User>(id);
                    transaction.Commit();
                    return user;
                }
            }
        }

        public User GetUserByCredentials(UserCredentials userCredentials)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var users = session.CreateCriteria<User>()
                                    .Add(Restrictions.Eq("Username", userCredentials.Username))
                                    .Add(Restrictions.Eq("Password", userCredentials.Password))
                                    .List<User>();
                    transaction.Commit();

                    if (users.Count() == 0)
                    {
                        return null;
                    }
                    User user = users[0];
                    return user;
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }

        public void DeleteUser(User user)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }

    }
}
