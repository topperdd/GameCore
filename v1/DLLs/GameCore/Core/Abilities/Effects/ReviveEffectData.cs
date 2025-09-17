using GameCore.Core.Interfaces;

namespace GameCore.Core.Abilities.Effects
{
    public class ReviveEffectData : EffectData
    {
        public IReviveable ReviveableTarget { get; set; }
    }
}
