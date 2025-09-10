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
        public void ApplyEffect()
        {
            Console.WriteLine($"Effect: {EffectData.EffectId} was used!");
        }
    }
}
