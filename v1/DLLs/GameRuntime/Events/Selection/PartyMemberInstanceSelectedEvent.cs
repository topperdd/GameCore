using GameCore.Partymember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRuntime.Events
{
    public class PartyMemberInstanceSelectedEvent
    {
        public PartymemberInstance PartymemberInstance { get; private set; }

        public PartyMemberInstanceSelectedEvent(PartymemberInstance partymemberInstance)
        {
            PartymemberInstance = partymemberInstance ?? throw new ArgumentNullException(nameof(partymemberInstance), "PartymemberInstance cannot be null.");
        }
    }
}
