namespace _08_MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; set; }
        string State { get; set; }

        void CompleteMission();
    }
}
