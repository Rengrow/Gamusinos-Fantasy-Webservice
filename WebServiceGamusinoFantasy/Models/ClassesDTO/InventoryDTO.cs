using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class InventoryDTO
    {
        public long id { get; set; }
        public ICollection<Inventory_ItemsDTO> Inventory_Items { get; set; }
        public ICollection<ArmorDTO> Armors { get; set; }
        public ICollection<WeaponDTO> Weapons { get; set; }

        public InventoryDTO(long id, HashSet<Inventory_ItemsDTO> Inventory_Items, HashSet<ArmorDTO> Armors, HashSet<WeaponDTO> Weapons)
        {
            this.id = id;
            this.Inventory_Items = Inventory_Items;
            this.Armors = Armors;
            this.Weapons = Weapons;
        }

        public InventoryDTO(long id)
        {
            this.id = id;
            this.Inventory_Items = new HashSet<Inventory_ItemsDTO>();
            this.Armors = new HashSet<ArmorDTO>();
            this.Weapons = new HashSet<WeaponDTO>();
        }

        public InventoryDTO(Inventory inventory)
        {
            this.id = inventory.id;

            int i = 0;
            bool parar = false;
            HashSet<Inventory_ItemsDTO> itemsDTO = new HashSet<Inventory_ItemsDTO>();
            HashSet<ArmorDTO> armorsDTO = new HashSet<ArmorDTO>();
            HashSet<WeaponDTO> weaponsDTO = new HashSet<WeaponDTO>();
            do
            {
                if (i < inventory.Inventory_Items.Count)
                    itemsDTO.Add(new Inventory_ItemsDTO(inventory.Inventory_Items.ElementAt(i)));

                if (i < inventory.Armors.Count)
                    armorsDTO.Add(new ArmorDTO(inventory.Armors.ElementAt(i)));

                if (i < inventory.Weapons.Count)
                    weaponsDTO.Add(new WeaponDTO(inventory.Weapons.ElementAt(i)));

                i++;

                if (inventory.Inventory_Items.Count <= i && inventory.Armors.Count <= i && inventory.Weapons.Count <= i)
                    parar = true;

            } while (!parar);

            this.Inventory_Items = itemsDTO;
            this.Armors = armorsDTO;
            this.Weapons = weaponsDTO;
        }

        public InventoryDTO()
        {
            this.Inventory_Items = new HashSet<Inventory_ItemsDTO>();
            this.Armors = new HashSet<ArmorDTO>();
            this.Weapons = new HashSet<WeaponDTO>();
        }

        public Inventory ToOriginalClass()
        {
            Inventory entity = new Inventory();
            entity.id = this.id;

            int i = 0;
            bool parar = false;
            HashSet<Inventory_Items> items = new HashSet<Inventory_Items>();
            HashSet<Armor> armors = new HashSet<Armor>();
            HashSet<Weapon> weapons = new HashSet<Weapon>();
            do
            {
                if (i < Inventory_Items.Count)
                    items.Add(this.Inventory_Items.ElementAt(i).ToOriginalClass());

                if (i < Armors.Count)
                    armors.Add(this.Armors.ElementAt(i).ToOriginalClass());

                if (i < Weapons.Count)
                    weapons.Add(this.Weapons.ElementAt(i).ToOriginalClass());

                i++;

                if (Inventory_Items.Count <= i && Armors.Count <= i && Weapons.Count <= i)
                    parar = true;

            } while (!parar);

            entity.Inventory_Items = items;
            entity.Armors = armors;
            entity.Weapons = weapons;
            return entity;
        }

        /*private List<HashSet<Object>> ConvertCollectionsToDTO(HashSet<Inventory_Items> Inventory_Items, HashSet<Armor> Armors, HashSet<Weapon> Weapons)
        {
            int i = 0;
            bool parar = false;
            HashSet<Object> itemsDTO = new HashSet<Object>();
            HashSet<Object> armorsDTO = new HashSet<Object>();
            HashSet<Object> weaponsDTO = new HashSet<Object>();
            do
            {
                if (i < Inventory_Items.Count)
                    itemsDTO.Add(new Inventory_ItemsDTO(Inventory_Items.ElementAt(i)));

                if (i < Armors.Count)
                    armorsDTO.Add(new ArmorDTO(Armors.ElementAt(i)));

                if (i < Weapons.Count)
                    weaponsDTO.Add(new WeaponDTO(Weapons.ElementAt(i)));

                i++;

                if (Inventory_Items.Count <= i && Armors.Count <= i && Weapons.Count <= i)
                    parar = true;
            } while (!parar);

            List<HashSet<Object>> entity = new List<HashSet<Object>>();
            entity.Add(itemsDTO);
            entity.Add(armorsDTO);
            entity.Add(weaponsDTO);
            return entity;
        } */
    }
}