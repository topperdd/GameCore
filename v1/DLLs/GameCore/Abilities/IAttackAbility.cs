using GameCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Abilities
{
    public interface IAttackAbility
    {
        public void ExecuteAttack(IDamageable target);
    }
}
