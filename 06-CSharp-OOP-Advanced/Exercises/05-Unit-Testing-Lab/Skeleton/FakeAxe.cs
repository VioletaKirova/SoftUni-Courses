public class FakeAxe : IWeapon
{
    public FakeAxe()
    {
        this.DurabilityPoints = 10;
    }

    public int AttackPoints => 10;

    public int DurabilityPoints { get; private set; }

    public void Attack(ITarget target)
    {
        target.TakeAttack(this.AttackPoints);
        this.DurabilityPoints -= 1;
    }
}
