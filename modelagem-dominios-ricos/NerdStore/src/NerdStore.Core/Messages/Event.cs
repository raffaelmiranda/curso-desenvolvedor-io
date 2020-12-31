using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; set; }
        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
