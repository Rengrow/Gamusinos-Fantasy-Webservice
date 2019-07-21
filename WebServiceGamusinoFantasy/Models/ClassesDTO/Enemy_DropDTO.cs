using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class Enemy_DropDTO
    {
        public decimal? dropRate { get; set; }
        public ItemDTO Item { get; set; }

        public Enemy_DropDTO(decimal dropRate, ItemDTO Item)
        {
            this.dropRate = dropRate;
            this.Item = Item;
        }

        public Enemy_DropDTO(decimal dropRate)
        {
            this.dropRate = dropRate;
            this.Item = new ItemDTO();
        }

        public Enemy_DropDTO(Enemy_Drop ed) 
        {
            this.dropRate = ed.dropRate;
            this.Item = new ItemDTO(ed.Item);
        }

        public Enemy_DropDTO()
        {
            this.Item = new ItemDTO();
        }

        public Enemy_Drop ToOriginalClass()
        {
            Enemy_Drop entity = new Enemy_Drop();
            entity.dropRate = this.dropRate;
            entity.Item = this.Item.ToOriginalClass();
            return entity;
        }
    }
}