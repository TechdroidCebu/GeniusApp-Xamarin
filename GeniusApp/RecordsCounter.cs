using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusApp
{
    [AddINotifyPropertyChangedInterface]
    public class RecordsCounter
    {
        public string cuMasterRecordCount { get; set; }
    }
}
