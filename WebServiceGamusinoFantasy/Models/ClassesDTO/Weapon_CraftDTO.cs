using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class Weapon_CraftDTO
    {
        public long quantity { get; set; }
        public ItemDTO Item { get; set; }

        public Weapon_CraftDTO(long quantity, ItemDTO Item)
        {
            this.quantity = quantity;
            this.Item = Item;
        }

        public Weapon_CraftDTO(long quantity)
        {
            this.quantity = quantity;
            this.Item = new ItemDTO();
        }

        public Weapon_CraftDTO(Weapon_Craft wc)
        {
            this.quantity = wc.quantity;
            this.Item = new ItemDTO(wc.Item);
        }

        public Weapon_CraftDTO()
        {
            this.Item = new ItemDTO();
        }

        public Weapon_Craft ToOriginalClass()
        {
            Weapon_Craft entity = new Weapon_Craft();
            entity.Item = this.Item.ToOriginalClass();
            entity.quantity = this.quantity;
            return entity;
        }

    }
}