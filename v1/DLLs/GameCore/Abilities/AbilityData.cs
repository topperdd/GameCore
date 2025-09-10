using GameCore.Interfaces;

namespace GameCore.Abilities
{
    public class AbilityData
    {
        public string AbilityId { get; set; } = string.Empty;

        public List<string> EffectIds { get; set; } = new List<string>();
    }
}

