//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceGamusinoFantasy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reward
    {
        public long Item_id { get; set; }
        public long Mission_id { get; set; }
        public Nullable<long> Quantity { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
