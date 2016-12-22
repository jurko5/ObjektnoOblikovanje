﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Factories;
using AccountingWPF.Models;

namespace AccountingWPF.Repositories
{
    public class ReceiptRepository : MonetaryFlowCRUD
    {

        public void Create(MonateryFlow monetaryFlow)
        {
            Console.WriteLine("Create receipt");
        }

        public void Delete(int id)
        {
            Console.WriteLine("Delete receipt");
        }

        public void Update(MonateryFlow monetaryFlow)
        {
            Console.WriteLine("Update receipt");
        }

        public MonateryFlow GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Receipt> getByUserId(int userId)
        {
            return Mock.getReceiptsByUserId(userId);
        }
    }
}
