using GameRuntime.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Abilities.Effects
{
    public class DamageEffect : IEffect
    {
        public EffectData EffectData { get; private set; }
        public DamageEffect(EffectData effectData)
        {
            EffectData = effectData;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            foreach (var monster in effectContext.Targets)
            {
                monster.TakeDamage(EffectData.Value);
            }
        }
    }
}
