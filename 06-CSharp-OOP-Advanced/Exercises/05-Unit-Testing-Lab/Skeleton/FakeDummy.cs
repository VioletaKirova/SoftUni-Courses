public class FakeDummy : ITarget
{
    public FakeDummy()
    {
        this.Health = 10;
    }

    public int Health { get; private set; }

    public int GiveExperience() => 10;

    public bool IsDead() => true;

    public void TakeAttack(int attackPoints) => this.Health -= attackPoints;
}
