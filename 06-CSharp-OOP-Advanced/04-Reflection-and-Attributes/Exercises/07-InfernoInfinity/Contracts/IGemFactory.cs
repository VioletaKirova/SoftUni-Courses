namespace _07_InfernoInfinity.Contracts
{
    using Enums;

    public interface IGemFactory
    {
        IGem CreateGem(string gemType, Clarity clarity);
    }
}
