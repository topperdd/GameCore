using GameCore.Core.Interfaces;
using GameCore.Runtime.Instances;

#nullable disable

namespace GameCore.Contexts
{
    public class EffectContext
    {
        public GameContext GameContext { get; set; }

        public List<IDamageable> DamageableTargets { get; set; }

        public IReviveable PartymemberToRevive { get; set; }

        public List<PartymemberInstance> PartymemberToConvert { get; set; }
    }
}
