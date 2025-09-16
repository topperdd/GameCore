using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Interfaces;

namespace GameCore.Runtime.Instances.Abilities
{
    public class AttackAbilityInstance : IAttackAbility
    {
        public AttackAbilityData Data { get; set; }
        public string AbilityId { get; set; }

        public List<IEffect> Effects { get; set; }
        public MonsterType MonsterToKill { get; }

        public AttackAbilityInstance(AttackAbilityData data, List<IEffect> effectData)
        {
            Data = data;
            Effects = effectData;
            MonsterToKill = data.MonsterTypeToKill;
            AbilityId = data.AbilityId;
        }

        public void ExecuteAbility<T>(T context)
        {
            var effectContext = context as EffectContext;

            foreach (var effect in Effects)
            {
                effect.ApplyEffect(effectContext);
            }
        }
    }
}
