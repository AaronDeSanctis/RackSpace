using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackSpaceWPF.Classes
{
    class LabEquipment
    {
        Guid guid { get; set; }
        DateTime LastCal { get; set; }
        DateTime NextCal { get; set; }
        string ModelName {get; set;}


    }
}
