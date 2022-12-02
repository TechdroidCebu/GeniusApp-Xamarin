using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeniusApp.Models;



namespace GeniusApp.Messages
{
    public class SetNodeLocationMessages : ValueChangedMessage<string>
    {
        public SetNodeLocationMessages(string value) : base(value)
        {

        }
    }
}
