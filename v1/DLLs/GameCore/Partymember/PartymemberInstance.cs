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

        public PartymemberInstance(PartymemberData data)
        {
            Data = data;
        }

    }
}
