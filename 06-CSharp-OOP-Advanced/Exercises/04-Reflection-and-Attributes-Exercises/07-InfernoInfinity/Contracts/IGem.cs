namespace _07_InfernoInfinity.Contracts
{
    using Enums;

    public interface IGem
    {
        Clarity ClarityLevel { get; }

        int StrengthBonus { get; }

        int AgilityBonus { get; }

        int VitalityBonus { get; }
    }
}
