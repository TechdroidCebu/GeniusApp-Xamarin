using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusApp.Models
{
    public class NodeTypeLibModel
    {
        [PrimaryKey, AutoIncrement]
        public int nodeTypeId { get; set; }
        public string nodeType { get; set; }
        public int nodeTypeLevel { get; set; }
        public string nodeDescription { get; set; }
    }
}
