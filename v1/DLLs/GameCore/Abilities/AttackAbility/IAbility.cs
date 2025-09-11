using GameCore.Interfaces;
using GameRuntime.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Abilities.AttackAbility
{
    public interface IAbility
    {
        public void ExecuteAbility(EffectContext effectContext);
    }
}
