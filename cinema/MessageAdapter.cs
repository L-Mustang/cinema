using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.lib;

namespace cinema
{
    public interface MessageAdapter
    {
        public void SendMessage(string message);
    }
}
