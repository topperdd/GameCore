
namespace GameCore.Core.Abilities.AttackAbility
{
    public class AttackAbilityData
    {
        public string AbilityId { get; set; } = string.Empty;
        public MonsterType MonsterTypeToKill { get; set; }
        public List<string> EffectIds { get; set; } = new List<string>();
    }
}

