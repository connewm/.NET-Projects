namespace Newman.RolePlayingGameInterfaces
{
    public interface ICharacter
    {
        // Properties
        string CharacterClass { get; }
        string Name { get; }
        int Health { get; }

        void PerformAttack(ICharacter target);
        void ReceiveAttack(int damage);
    }


}
