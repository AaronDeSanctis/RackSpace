using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackSpaceWPF.Classes
{
    class ThermoCouple : Item
    {
        int BundleSize { get; set; }
        bool IsHighTemp { get; set; }
        string TCId { get; set; }
    }
}
