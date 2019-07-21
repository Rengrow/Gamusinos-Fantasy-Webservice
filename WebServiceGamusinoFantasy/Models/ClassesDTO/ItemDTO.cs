using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class ItemDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public ItemDTO(long id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public ItemDTO(Item Item)
        {
            this.id = Item.id;
            this.name = Item.name;
            this.description = Item.description;
        }

        public ItemDTO()  {}

        public Item ToOriginalClass()
        {
            Item entity = new Item();
            entity.id = this.id;
            entity.name = this.name;
            entity.description = this.description;
            return entity;
        }
    }
}