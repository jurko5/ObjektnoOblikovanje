﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Factories;
using AccountingWPF.Models;

namespace AccountingWPF.Repositories
{
    class OutgoingInvoiceRepository : InvoiceCRUD
    {
        public void Create(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public IList<OutgoingInvoice> getByUserId(int userId)
        {

            return Mock.getOutgoingInvoicesByUserId(userId);
        }
    }
}
