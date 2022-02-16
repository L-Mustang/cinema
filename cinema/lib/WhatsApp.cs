using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.lib
{
    public class WhatsApp
    {
        private string userId;
        private string token;

        public WhatsApp(string userId, string token)
        {
            this.userId = userId;
            this.token = token;
        }
        public bool POSTMessage(string msg)
        {
            Console.Out.WriteLine(msg);
            return true;
        }

    }
}
