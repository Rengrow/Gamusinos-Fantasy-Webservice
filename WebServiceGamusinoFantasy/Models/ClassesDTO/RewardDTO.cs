using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class RewardDTO
    {
        public long? Quantity { get; set; }
        public ItemDTO Item { get; set; }

        public RewardDTO(long Quantity, ItemDTO Item)
        {
            this.Quantity = Quantity;
            this.Item = Item;
        }

        public RewardDTO(long Quantity)
        {
            this.Quantity = Quantity;
            this.Item = new ItemDTO();
        }

        public RewardDTO(Reward reward)
        {
            this.Quantity = reward.Quantity;
            this.Item = new ItemDTO(reward.Item);
        }

        public RewardDTO()
        {
            Item = new ItemDTO();
        }

        public Reward ToOriginalClass()
        {
            Reward entity = new Reward();
            entity.Quantity = this.Quantity;
            entity.Item = this.Item.ToOriginalClass();
            return entity;
        }
    }
}