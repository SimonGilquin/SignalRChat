using Cellenza.Demo.SignalR.WebServer.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellenza.Demo.SignalR.WebServer.Connections
{
    public class MessageConnection : PersistentConnection
    {
        public ICollection<Message> MessagesStore { get; set; }

        public MessageConnection()
        {
            MessagesStore = MessagesRepository.Instance;
        }

        public MessageConnection(ICollection<Message> store)
        {
            MessagesStore = store;
        }


        protected override System.Threading.Tasks.Task OnReceived(IRequest request, string connectionId, string data)
        {
            var message = JsonSerializer.Parse(data, typeof(Message)) as Message;
            MessagesStore.Add(message);
            return Connection.Broadcast(message);
        }
    }
}