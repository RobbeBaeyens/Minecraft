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
    
    public partial class Inventory
    {
        public Inventory()
        {
            this.Inventory_Item = new HashSet<Inventory_Item>();
            this.Inventory_Player = new HashSet<Inventory_Player>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Inventory_Item> Inventory_Item { get; set; }
        public virtual ICollection<Inventory_Player> Inventory_Player { get; set; }
    }
}
