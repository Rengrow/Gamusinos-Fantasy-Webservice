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
    
    public partial class Armor_Craft
    {
        public long Item_id { get; set; }
        public long Armor_id { get; set; }
        public long quantity { get; set; }
    
        public virtual Armor Armor { get; set; }
        public virtual Item Item { get; set; }
    }
}