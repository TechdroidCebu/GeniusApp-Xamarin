using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeniusApp.Models;



namespace GeniusApp.Messages
{
    public class SetJaIDMessages : ValueChangedMessage<string>
    {
        public SetJaIDMessages(string value) : base(value)
        {

        }
    }
}
