namespace Banks.Clients
{
    public class Client
    {
        private static int _idCounter;

        public Client(string name, string surname, string address, string passport)
        {
            Id = _idCounter++;
            Name = name;
            Surname = surname;
            Address = address;
            Passport = passport;
        }

        public int Id { get; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Address { get; private set; }
        public string Passport { get; private set; }
    }
}