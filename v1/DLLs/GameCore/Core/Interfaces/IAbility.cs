using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Core.Interfaces
{
    public interface IAbility
    {
        public string AbilityId { get; set; }

        public void ExecuteAbility<T>(T context);
    }
}
