using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.lib;

namespace cinema
{
    public class MessageAdapterWhatsApp : MessageAdapter
    {
        private WhatsApp instance;
        public string message;

        public MessageAdapterWhatsApp()
        {
            //Dummy data
            this.instance = new WhatsApp("auhfuwhebfn", "aojwebfuhebf");
        }

        public void SendMessage(string message)
        {
            this.message = message;
            //Dummy receiver
            instance.POSTMessage("Whatsaap: " + message);
        }
    }
}
