using GameCore.Abilities.AttackAbility;
using GameCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Partymember
{
    public class PartymemberInstance
    {
        public PartymemberData Data { get; set; }
        public List<IAttackAbility> AttackAbilities { get; set; } = new List<IAttackAbility>();   

        public PartymemberInstance(PartymemberData data, List<IAttackAbility> attackAbilities)
        {
            Data = data;
            AttackAbilities = attackAbilities;
        }
    }
}
