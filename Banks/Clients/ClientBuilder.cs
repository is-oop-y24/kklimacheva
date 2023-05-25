using Banks.Exceptions;

namespace Banks.Clients
{
    public class ClientBuilder : IBuilder
    {
        private static string _name;
        private static string _surname;
        private static string _address;
        private static string _passport;
        private Client _client = new Client(_name, _surname, _address, _passport);

        public ClientBuilder()
        {
        }

        public IBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IBuilder SetSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public IBuilder SetAddress(string address)
        {
            _address = address;
            return this;
        }

        public IBuilder SetPassport(string passport)
        {
            _passport = passport;
            return this;
        }

        public Client Build()
        {
            return new Client(_name, _surname, _passport, _address);
        }

        public Client GetClient()
        {
            if (string.IsNullOrEmpty(_client.Name) || string.IsNullOrEmpty(_client.Surname))
            {
                throw new ClientException("Invalid name or surname.");
            }

            return _client;
        }
    }
}