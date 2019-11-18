namespace Database
{
    public interface IDatabase
    {
        int Count { get; }

        IPerson[] Data { get; }

        void Add(IPerson element);

        void Remove();

        IPerson FindByUsername(string username);

        IPerson FindById(long id);       
    }
}
