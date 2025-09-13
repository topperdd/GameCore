using GameCore.Contexts;

namespace GameCore.Core.Abilities.Effects
{
    public interface IEffect
    {
        void ApplyEffect(EffectContext effectContext);
    }
}
