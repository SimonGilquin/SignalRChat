using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellenza.Demo.SignalR.WebServer.Models
{
    public class MessagesRepository
    {
        public static ICollection<Message> Instance = new List<Message>();

        private MessagesRepository ()
	    {

	    }
    }
}