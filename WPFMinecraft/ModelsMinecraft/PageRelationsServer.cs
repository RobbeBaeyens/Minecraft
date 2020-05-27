using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALMinecraft;

namespace ModelsMinecraft
{
    public class PageRelationsServer
    {
        public int ServerId { get; set; }

        public PageRelationsServer(int serverId)
        {
            this.ServerId = serverId;
        }
    }
}
