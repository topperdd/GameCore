using GameCore.Interfaces;

namespace GameCore.Abilities
{
    public class AttackAbilityData
    {
        public string AbilityName { get; set; }

        public List<string> AttackEffects { get; set; } = new List<string>();
    }
}
