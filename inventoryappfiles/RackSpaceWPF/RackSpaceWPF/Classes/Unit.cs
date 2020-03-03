using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackSpaceWPF.Classes
{
    class Unit : Item
    {
        string ModelName { get; set; }
        string Voltage { get; set; }
        string SerialNumber { get; set; }
        bool Is3Phase { get; set; }


    }
}
