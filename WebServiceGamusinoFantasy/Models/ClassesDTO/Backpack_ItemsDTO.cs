using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class Backpack_ItemsDTO
    {
        public long Backpack_id { get; set; }
        public long Item_id { get; set; }
        public long? Quantity { get; set; }
        public ItemDTO Item { get; set; }

        public Backpack_ItemsDTO(long Backpack_id, long Item_id, long Quantity, ItemDTO Item)
        {
            this.Backpack_id = Backpack_id;
            this.Item_id = Item_id;
            this.Quantity = Quantity;
            this.Item = Item;
        }

        public Backpack_ItemsDTO(long Backpack_id, long Item_id, long Quantity)
        {
            this.Backpack_id = Backpack_id;
            this.Item_id = Item_id;
            this.Quantity = Quantity;
            this.Item = new ItemDTO();
        }

        public Backpack_ItemsDTO(Backpack_Items backpack_items)
        {
            this.Backpack_id = backpack_items.Backpack_id;
            this.Item_id = backpack_items.Item_id;
            this.Quantity = backpack_items.Quantity;
            this.Item = new ItemDTO(backpack_items.Item);
        }

        public Backpack_ItemsDTO()
        {
            this.Item = new ItemDTO();
        }

        public Backpack_Items ToOriginalClass()
        {
            Backpack_Items entity = new Backpack_Items();
            entity.Backpack_id = this.Backpack_id;
            entity.Item_id = this.Item_id;
            entity.Quantity = this.Quantity;
            entity.Item = this.Item.ToOriginalClass();
            return entity;
        }
    }
}