using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class BackpackDTO
    {
        public ICollection<Backpack_ItemsDTO> Backpack_Items { get; set; }

        public BackpackDTO(Backpack backpack)
        {
            ICollection<Backpack_ItemsDTO> collection = new HashSet<Backpack_ItemsDTO>();
            foreach (Backpack_Items item in backpack.Backpack_Items)
            {
                collection.Add(new Backpack_ItemsDTO(item));
            }
            this.Backpack_Items = collection;
        }

        public BackpackDTO(HashSet<Backpack_Items> backpackItems)
        {
            ICollection<Backpack_ItemsDTO> collection = new HashSet<Backpack_ItemsDTO>();
            foreach (Backpack_Items item in backpackItems)
            {
                collection.Add(new Backpack_ItemsDTO(item));
            }
            this.Backpack_Items = collection;
        }

        public BackpackDTO()
        {
            this.Backpack_Items = new HashSet<Backpack_ItemsDTO>();
        }

        public Backpack ToOriginalClass()
        {
            Backpack entity = new Backpack();
            ICollection<Backpack_Items> collection = new HashSet<Backpack_Items>();
            foreach (Backpack_ItemsDTO item in this.Backpack_Items)
            {
                collection.Add(item.ToOriginalClass());
            }
            entity.Backpack_Items = collection;
            return entity;
        }
    }
}