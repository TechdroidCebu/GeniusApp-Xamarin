using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusApp.Models
{
    public class CuMasterModel
    {
        /*{
  "cuId": 0,
  "cuNumber": "string",
  "cuDescription": "string",
  "cuType": "string",
  "businessUnit": "string",
  "assetClass": "string",
  "hierarchyLevel": 0,
  "difficulty": "string",
  "cuStatus": true,
  "dtAdded": "2022-11-26T12:05:09.580Z",
  "addedBy": "string",
  "dtUpdated": "2022-11-26T12:05:09.580Z",
  "updatedby": "string"
}*/

        public int cuId { get; set; }
        public string cuNumber { get; set; }
        public string cuDescription { get; set; }
        public string cuType { get; set; }
        public string businessUnit { get; set; }    
        public string assetClass { get; set; }  
        public Nullable<int> hierarchyLevel { get; set; }       
        public string difficulty { get; set; }
        public bool cuStatus { get; set; }
        public DateTime dtAdded { get; set; }
        public string addedBy { get; set; }
        public DateTime dtUpdated { get; set; }
        public string updatedby { get; set; }

    }
}
