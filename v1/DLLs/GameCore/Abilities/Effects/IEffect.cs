using GameRuntime.Contexts;

namespace GameCore.Abilities.Effects
{
    public interface IEffect
    {
        void ApplyEffect(EffectContext effectContext);
    }
}
