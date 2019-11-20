namespace Heroes.Models.Contracts
{
    public interface ISubject
    {
        void Register(IObserver observer);

        void Unregister(IObserver observer);

        void NotifyObservers();
    }
}
