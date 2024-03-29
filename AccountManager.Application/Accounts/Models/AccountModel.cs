﻿using AccountManager.Application.Transactions.Models;

namespace AccountManager.Application.Accounts.Models
{
    public class AccountModel
    {
        public decimal Balance { get; set; }
        public List<TransactionModel> Transactions { get; set; }
    }
}
