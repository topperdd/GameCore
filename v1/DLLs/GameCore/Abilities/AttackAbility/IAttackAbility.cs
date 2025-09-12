using GameCore.Interfaces;
using GameRuntime.Contexts;

namespace GameCore.Abilities.AttackAbility
{
    public interface IAttackAbility
    {
        public void ExecuteAttack(EffectContext effectContext);
    }
}
