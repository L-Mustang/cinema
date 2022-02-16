using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.lib
{
    public class IMessage
    {
        public void SendMessage(string msg, int receiverID)
        {
            Console.Out.WriteLine(msg);
        }
    }
}
