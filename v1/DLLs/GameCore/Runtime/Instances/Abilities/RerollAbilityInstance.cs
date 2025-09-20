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


        public RerollAbilityInstance(RerollAbilityData data)
        {
            Data = data;
            AbilityId = data.AbilityId;
        }

        public void ExecuteAbility<T>(T context)
        {
            
        }
    }
}
