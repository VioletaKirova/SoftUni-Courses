namespace Database
{
    public interface IDatabase
    {
        int Count { get; }

        int[] Data { get; }

        void Add(int element);

        void Remove();

        int[] Fetch();
    }
}
