using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Bank;
using Banks.Clients;
using Banks.Exceptions;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BanksTests
    {
        private ClientBuilder _builder;
        private CentralBank _centralBank;

        [SetUp]
        public void Setup()
        {
            _builder = new ClientBuilder();
            _centralBank = CentralBank.GetInstance();
        }

        [Test]
        public void ClientWithoutSurname_ThrowException()
        {
            Assert.Catch<ClientException>(() =>
            {
                Client newClient = _builder.SetName("Kate").SetSurname("").GetClient();
            });
        }
    }
}