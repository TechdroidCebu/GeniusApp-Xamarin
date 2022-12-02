using SQLite;
using System;

namespace GeniusApp.Models
{
    public class JobActivityModel    {
        [PrimaryKey, AutoIncrement]
        public int jaId { get; set; }
        public int jaNumber { get; set; }
        public int joId { get; set; }    
        public string crewMemberList { get; set; }
        public int assetClassId { get; set; }   
        public float jaDaysRequired { get; set; }
        public DateTime proposedStartDate { get; set; }  
        public int jaDaysAccumulated { get; set; }
        public DateTime jaActualStartDate { get; set; }
        public DateTime jaActualFinished { get; set; }
        public int laborCost { get; set; }
        public string laborCostUnit { get; set; }
    }
}
