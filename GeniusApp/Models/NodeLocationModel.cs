using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusApp.Models
{
    public class NodeLocationModel: INotifyPropertyChanged
    {
        private double _latitude;
        private double _longitude;
        public double Latitude 
        { 
            get => _latitude; set 
            { 
                _latitude = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Latitude)));
            
            } 
        }
        

        public double Longitude
        {
            get => _longitude; set
            {
                _longitude = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Longitude)));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
