using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusApp.Messages
{
    public class DeleteItemMessage : ValueChangedMessage<string>
    {
        public DeleteItemMessage(string value) : base(value)
        {

        }
    }
}
