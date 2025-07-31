using GameCore.Interfaces;

namespace GameCore.Abilities
{
    public class AttackAbilityInstance : IAttackAbility
    {
        public AttackAbilityData Data { get; set; }

        public AttackAbilityInstance(AttackAbilityData data)
        {
            Data = data;
        }

        public void ExecuteAttack(IDamageable target)
        {
            Console.WriteLine($"Executing attack with ability: {Data.AbilityName}");
        }
    }
}
