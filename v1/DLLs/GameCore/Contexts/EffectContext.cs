using GameCore.Core.Interfaces;

#nullable disable

namespace GameCore.Contexts
{
    public class EffectContext
    {
        public List<IDamageable> DamageableTargets { get; set; }

        public IReviveable PartymemberToRevive { get; set; }
    }
}
