//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALMinecraft
{
    using System;
    using System.Collections.Generic;
    
    public partial class World
    {
        public World()
        {
            this.Server = new HashSet<Server>();
            this.World_Dimension = new HashSet<World_Dimension>();
            this.World_Setting = new HashSet<World_Setting>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string seed { get; set; }
    
        public virtual ICollection<Server> Server { get; set; }
        public virtual ICollection<World_Dimension> World_Dimension { get; set; }
        public virtual ICollection<World_Setting> World_Setting { get; set; }
    }
}
