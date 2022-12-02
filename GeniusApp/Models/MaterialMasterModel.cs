using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusApp.Models
{
    public class MaterialMasterModel
    {
        /*{
  "matId": 0,
  "stockCode": "string",
  "itemCode": "string",
  "materialDescription": "string",
  "unitOfMeasure": "string",
  "matStatus": true,
  "dtUpdated": "2022-11-27T03:21:51.630Z"
}*/

        public int matId { get; set;}
        public string stockCode { get; set; }
        public string itemCode { get; set; }
        public string materialDescription { get; set; }
        public string unitOfMeasure { get; set; }
        public bool matStatus { get; set; }
        public DateTime dtUpdated { get; set; }
    }
}
