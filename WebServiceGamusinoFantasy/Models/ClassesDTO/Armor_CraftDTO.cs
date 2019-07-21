using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class Armor_CraftDTO
    {
        public long quantity { get; set; }
        public ItemDTO Item { get; set; }

        public Armor_CraftDTO(long quantity, ItemDTO Item) 
        {
            this.quantity = quantity;
            this.Item = Item;
        }

        public Armor_CraftDTO(long quantity)
        {
            this.quantity = quantity;
            this.Item = new ItemDTO();
        }

        public Armor_CraftDTO(Armor_Craft ac)
        {
            this.quantity = ac.quantity;
            this.Item = new ItemDTO(ac.Item);
        }

        public Armor_CraftDTO()
        {
            this.Item = new ItemDTO();
        }

        public Armor_Craft ToOriginalClass()
        {
            Armor_Craft entity = new Armor_Craft();
            entity.Item = this.Item.ToOriginalClass();
            entity.quantity = this.quantity;
            return entity;
        }
    }
}