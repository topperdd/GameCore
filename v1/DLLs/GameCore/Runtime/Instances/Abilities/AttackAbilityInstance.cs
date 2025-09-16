using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.Effects;

namespace GameCore.Runtime.Instances.Abilities
{
    public class AttackAbilityInstance : IAttackAbility
    {
        public AttackAbilityData Data { get; set; }

        public List<IEffect> Effects { get; set; }
        public MonsterType MonsterToKill { get; }
        public string AbilityId { get; }

        public AttackAbilityInstance(AttackAbilityData data, List<IEffect> effectData)
        {
            Data = data;
            Effects = effectData;
            MonsterToKill = data.MonsterTypeToKill;
            AbilityId = data.AbilityId;
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
