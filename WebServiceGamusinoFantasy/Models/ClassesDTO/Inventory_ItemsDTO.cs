using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class Inventory_ItemsDTO
    {
        public long Item_id { get; set; }
        public long Inventory_id { get; set; }
        public long? Quantity { get; set; }
        public ItemDTO Item { get; set; }

        public Inventory_ItemsDTO(long Item_id, long Inventory_id, long Quantity, ItemDTO Item)
        {
            this.Item_id = Item_id;
            this.Inventory_id = Inventory_id;
            this.Quantity = Quantity;
            this.Item = Item;
        }

        public Inventory_ItemsDTO(long Item_id, long Inventory_id, long Quantity)
        {
            this.Item_id = Item_id;
            this.Inventory_id = Inventory_id;
            this.Quantity = Quantity;
            this.Item = new ItemDTO();
        }

        public Inventory_ItemsDTO(Inventory_Items Inventory_Items)
        {
            this.Item_id = Inventory_Items.Item_id;
            this.Inventory_id = Inventory_Items.Inventory_id;
            this.Quantity = Inventory_Items.Quantity;
            this.Item = new ItemDTO(Inventory_Items.Item);
        }

        public Inventory_ItemsDTO()
        {
            this.Item = new ItemDTO();
        }

        public Inventory_Items ToOriginalClass()
        {
            Inventory_Items entity = new Inventory_Items();
            entity.Item_id = this.Item_id;
            entity.Inventory_id = this.Inventory_id;
            entity.Quantity = this.Quantity;
            entity.Item = this.Item.ToOriginalClass();
            return entity;
        }
    }
}