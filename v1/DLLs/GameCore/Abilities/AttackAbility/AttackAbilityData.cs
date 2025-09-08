using GameCore.Abilities.AttackAbility.AttackEffects;
using GameCore.Interfaces;

namespace GameCore.Abilities.AttackAbility
{
    public class AttackAbilityData
    {
        public string AbilityName { get; set; } = String.Empty;

        public List<IAttackEffect> AttackEffects { get; set; } = new List<IAttackEffect>();
    }
}

