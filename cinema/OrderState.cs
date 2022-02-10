using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public interface OrderState
    {
        public void edit();
        public void submit();
        public void pay();
        public void provision();
        public void cancel();
    }
}
