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
    
    public partial class Player_Dimension
    {
        public int id { get; set; }
        public Nullable<int> playerId { get; set; }
        public Nullable<int> dimensionId { get; set; }
    
        public virtual Dimension Dimension { get; set; }
        public virtual Player Player { get; set; }
    }
}
