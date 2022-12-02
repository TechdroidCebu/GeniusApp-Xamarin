﻿using SQLite;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusApp.Models
{
    public class NodeMasterModel
    {
        /*{
          "nodeId": 0,
          "nodeType": 0,
          "lat": 0,
          "long": 0,
          "dtConstructed": "2022-11-27T06:43:14.798Z",
          "dtActivatedOrUsed": "2022-11-27T06:43:14.798Z",
          "purposeBits": 0,
          "cityMunicipalityDerived": "string",
          "barangayDerived": "string",
          "sitioPurok": "string",
          "zoneDerived": "string",
          "jaId": 0,
          "photo": "string",
          "autoSequence": 0,
          "tempNodeTag": "string"
        }*/
        [PrimaryKey] [AutoIncrement]
        public int m_node_Id { get; set; }
        public int nodeId { get; set; }
        public int nodeType { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public DateTime dtConstructed { get; set; }
        public DateTime dtActivatedOrUsed { get; set; }
        public int purposeBits { get; set; }
        public string cityMunicipalityDerived { get; set; }
        public string barangayDerived { get; set; }
        public string sitioPurok { get; set; }
        public string zoneDerived { get; set; }       
        public int jaId { get; set; }
        public string photo { get; set; }        
        public int autoSequence { get; set; }
        public string tempNodeTag { get; set; }
    }
}
