using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BanksTests
    {
        private CentralBank _centralBank;
        private Client.Builder _builder;
        
        [SetUp]
        public void Setup()
        {
            _builder = new Client.Builder();
            _centralBank = CentralBank.GetInstance();
        }

        [Test]
        public void ClientWithoutSurname_ThrowException()
        {
            Assert.Catch<BanksException>(() =>
            {
                Client newClient = _builder.SetName("Kate").SetSurname("").GetClient();
            });
        }

        [Test]
        public void ClientWithoutPassportOrAddress_ThrowException()
        {
            Assert.Catch<BanksException>(() =>
            {

                Bank newBank = _centralBank.RegisterNewBank("Tinkoff");
                Client newClient = newBank.RegisterNewClient("Kate", "Klimacheva", "", "");
                var newBankAccount = new BankDebitAccount(231412);
                newClient.OpenNewDebitAccount(newBank, newBankAccount, 62316192);
            });
        }

        [Test]
        public void WithdrawOrTransferMoneyFromDepositAccount_ThrowException()
        {
            Assert.Catch<BanksException>(() =>
            {
                Bank newBank = _centralBank.RegisterNewBank("Tinkoff");
                Client newClient = newBank.RegisterNewClient("Kate", "Klimacheva", "1001", "kronva 49");
                var conditions = new SortedDictionary<double, double>();
                conditions.Add(300, 5);
                conditions.Add(123050, 13);
                var expTime = new DateTime(2022, 11, 23);
                var newBankAccount = new BankDepositAccount(conditions, expTime);
                newClient.OpenNewDepositAccount(newBank, newBankAccount, 31000);
                newClient.WithdrawMoney(newClient.Accounts().First(), 60000);
            });
        }
    }
}