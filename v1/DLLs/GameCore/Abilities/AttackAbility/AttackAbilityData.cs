using GameCore.Interfaces;

namespace GameCore.Abilities.AttackAbility
{
    public class AttackAbilityData
    {
        public string AttackAbilityId { get; set; } = String.Empty;

        public List<string> AttackEffects { get; set; } = new List<string>();
    }
}

