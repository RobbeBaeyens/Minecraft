//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALMinecraft
{
    using System;
    using System.Collections.Generic;
    
    public partial class Player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Player()
        {
            this.Inventory_Player = new HashSet<Inventory_Player>();
            this.Player_Advancement = new HashSet<Player_Advancement>();
            this.Player_Dimension = new HashSet<Player_Dimension>();
            this.Player_Effect = new HashSet<Player_Effect>();
            this.Player_Recipe = new HashSet<Player_Recipe>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
        public Nullable<decimal> health { get; set; }
        public Nullable<decimal> food { get; set; }
        public Nullable<decimal> armor { get; set; }
        public string skin { get; set; }
        public decimal posX { get; set; }
        public decimal posY { get; set; }
        public decimal posZ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Player> Inventory_Player { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player_Advancement> Player_Advancement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player_Dimension> Player_Dimension { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player_Effect> Player_Effect { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player_Recipe> Player_Recipe { get; set; }
    }
}