using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackSpaceWPF.Classes
{
    public class Note
    {
        public Guid guid { get; set; }
        public string Text { get; set; }
        public string ItemType { get; set; }
        public Guid ItemGuid { get; set; }
        public DateTime TimeStamp { get; set; }

        // Will add when subnote, user/role is more integrated
        public Guid UserGuid { get; set; }
        public bool IsSubNote { get; set; }
        public Guid SubNoteTargetGuid { get; set; }

    }
}
