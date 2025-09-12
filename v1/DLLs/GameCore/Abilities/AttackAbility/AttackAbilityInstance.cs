using GameCore.Abilities.Effects;
using GameCore.DungeonEntities.Monsters;
using GameRuntime.Contexts;

namespace GameCore.Abilities.AttackAbility
{
    public class AttackAbilityInstance : IAttackAbility
    {
        public AttackAbilityData Data { get; set; }
        public List<IEffect> Effects { get; set; }

        public AttackAbilityInstance(AttackAbilityData data, List<IEffect> effectData)
        {
            Data = data;
            Effects = effectData;
        }

        public void ExecuteAttack(EffectContext effectContext)
        {
            foreach (var effect in Effects)
            {
                effect.ApplyEffect(effectContext);
            }
        }
    }
}
