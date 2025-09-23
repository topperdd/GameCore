using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Abilities.RerollAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Runtime.Instances.Abilities
{
    internal class RerollAbilityInstance : IRerollAbility
    {
        public string AbilityId { get; set; }

        public RerollAbilityData Data { get; set; }

        public IEffect Effect { get; set; }


        public RerollAbilityInstance(RerollAbilityData data, IEffect effectData)
        {
            Data = data;
            AbilityId = data.AbilityId;
            Effect = effectData;
        }

        public void ExecuteAbility<T>(T context)
        {
            var effectContext = context as EffectContext;

            Effect.ApplyEffect(effectContext);
        }
    }
}
