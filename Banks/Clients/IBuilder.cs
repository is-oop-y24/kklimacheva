namespace Banks.Clients
{
    public interface IBuilder
    {
        IBuilder SetName(string name);
        IBuilder SetSurname(string surname);
        IBuilder SetAddress(string address);
        IBuilder SetPassport(string passport);
        Client Build();
        Client GetClient();
    }
}