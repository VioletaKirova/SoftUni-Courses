namespace Solid.Logger.Layouts.Factories.Contracts
{
    using Solid.Logger.Layouts.Contracts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
