using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.lib;

namespace cinema
{
    public class MessageAdapterFacebook : MessageAdapter
    {
        private FacebookMessenger instance;
        public string message;

        public MessageAdapterFacebook()
        {
            this.instance = new FacebookMessenger();
        }

        public void SendMessage(string message)
        {
            this.message = "Facebook: " + message;
            //Dummy receiver
            instance.SendFBMessage("Facebook: "+ message, 1);
        }
    }
}
