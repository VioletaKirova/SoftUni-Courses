namespace Heroes.Commands.Contracts
{
    using Models.Contracts;

    public interface IAttackGroup
    {
        void AddMember(IAttacker attacker);

        void GroupTarget(ITarget target);

        void GroupAttack();
    }
}
