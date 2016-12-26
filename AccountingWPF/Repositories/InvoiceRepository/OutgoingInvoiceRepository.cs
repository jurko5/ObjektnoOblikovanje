﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingWPF.Factories;
using AccountingWPF.Models;
using AccountingWPF.nHibernateDb;
using NHibernate;
using NHibernate.Linq;

namespace AccountingWPF.Repositories
{
    public class OutgoingInvoiceRepository<Invoice> : IInvoiceRepository<Invoice>
    {
        public void Create(Invoice invoice)
        {
            using (var session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(invoice);
                    transaction.Commit();
                }
            }
        }

        public void Delete(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Invoice invoice = session.Get<Invoice>(id);
                    if (invoice == null)
                    {
                        MessageBox.Show("Invoice for given id does not exists");
                        transaction.Commit();
                        return;
                    }
                    session.Delete(invoice);
                    transaction.Commit();
                }
            }
        }

        public Invoice GetById(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Invoice data = session.Get<Invoice>(id);
                    transaction.Commit();
                    return data;
                }
            }
        }

        public void Update(Invoice invoice)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(invoice);
                    transaction.Commit();
                }
            }
        }

        public IList<Invoice> getByUserId(int userId)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Invoice> list = (IList<Invoice>)session.Query<OutgoingInvoice>()
                                                                 .Where(x => x.FK_UserId == userId)
                                                                 .ToList();
                    transaction.Commit();
                    return list;
                }
            }
        }
    }
}
