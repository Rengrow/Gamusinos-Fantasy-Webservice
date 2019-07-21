using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class PlayerDTO
    {
        public long id { get; set; }
        public long expPoints { get; set; }
        public long vitality { get; set; }
        public long resistance { get; set; }
        public long force { get; set; }
        public long speed { get; set; }
        public long luck { get; set; }
        public long Inventory_id { get; set; }
        public long Backpack_id { get; set; }
        public long Weapon_id { get; set; }
        public long Armor_id { get; set; }
        public string rank { get; set; }
        public ArmorDTO Armor { get; set; }
        public BackpackDTO Backpack { get; set; }
        public InventoryDTO Inventory { get; set; }
        public WeaponDTO Weapon { get; set; }
        public ICollection<MissionDTO> CompletedMissions { get; set; }
        public bool ShouldSerialize()
        {
            return true;
        }

        public PlayerDTO(long id, long expPoints, long vitality, long resistance, long force, long speed, long luck, long Inventory_id, long Backpack_id, long Weapon_id, long Armor_id, string rank, ArmorDTO Armor, BackpackDTO Backpack, InventoryDTO Inventory, WeaponDTO Weapon, HashSet<MissionDTO> Missions)
        {
            this.id = id;
            this.expPoints = expPoints;
            this.vitality = vitality;
            this.resistance = resistance;
            this.force = force;
            this.speed = speed;
            this.luck = luck;
            this.Inventory_id = Inventory_id;
            this.Backpack_id = Backpack_id;
            this.Weapon_id = Weapon_id;
            this.Armor_id = Armor_id;
            this.rank = rank;
            this.Armor = Armor;
            this.Backpack = Backpack;
            this.Inventory = Inventory;
            this.Weapon = Weapon;
            this.CompletedMissions = Missions;
        }

        public PlayerDTO(long id, long expPoints, long vitality, long resistance, long force, long speed, long luck, long Inventory_id, long Backpack_id, long Weapon_id, long Armor_id, string rank)
        {
            this.id = id;
            this.expPoints = expPoints;
            this.vitality = vitality;
            this.resistance = resistance;
            this.force = force;
            this.speed = speed;
            this.luck = luck;
            this.Inventory_id = Inventory_id;
            this.Backpack_id = Backpack_id;
            this.Weapon_id = Weapon_id;
            this.Armor_id = Armor_id;
            this.rank = rank;
            this.Armor = new ArmorDTO();
            this.Backpack = new BackpackDTO();
            this.Inventory = new InventoryDTO();
            this.Weapon = new WeaponDTO();
            this.CompletedMissions = new HashSet<MissionDTO>();
        }

        public PlayerDTO(Player player)
        {
            this.id = player.id;
            this.expPoints = player.expPoints;
            this.vitality = player.vitality;
            this.resistance = player.resistance;
            this.force = player.force;
            this.speed = player.speed;
            this.luck = player.luck;
            this.Inventory_id = player.Inventory_id;
            this.Backpack_id = player.Backpack_id;
            this.Weapon_id = player.Weapon_id;
            this.Armor_id = player.Armor_id;
            this.rank = player.rank;
            this.Armor = new ArmorDTO(player.Armor);
            this.Backpack = new BackpackDTO(player.Backpack);
            this.Inventory = new InventoryDTO(player.Inventory);
            this.Weapon = new WeaponDTO(player.Weapon);
            HashSet<MissionDTO> missions = new HashSet<MissionDTO>();
            foreach (Mission item in player.CompletedMissions)
            {
                missions.Add(new MissionDTO(item));
            }
            this.CompletedMissions = missions;
        }

        public PlayerDTO()
        {
            this.Armor = new ArmorDTO();
            this.Backpack = new BackpackDTO();
            this.Inventory = new InventoryDTO();
            this.Weapon = new WeaponDTO();
            this.CompletedMissions = new HashSet<MissionDTO>();
        }

        public bool ShouldSerializeInventory()
        {
            // only serialize Username if SerializeSensitiveInfo == true
            return (this.SerializeVirtualProperties);
        }

        public bool ShouldSerializeInventory_id()
        {
            return (this.SerializeVirtualProperties);
        }

        [JsonIgnore]
        public bool SerializeVirtualProperties { get; set; }

        public Player ToOriginalClass()
        {
            Player entity = new Player();
            entity.id = this.id;
            entity.expPoints = this.expPoints;
            entity.vitality = this.vitality;
            entity.resistance = this.resistance;
            entity.force = this.force;
            entity.speed = this.speed;
            entity.luck = this.luck;
            entity.Inventory_id = this.Inventory_id;
            entity.Backpack_id = this.Backpack_id;
            entity.Weapon_id = this.Weapon_id;
            entity.Armor_id = this.Armor_id;
            entity.rank = this.rank;
            entity.Armor = this.Armor.ToOriginalClass();
            entity.Backpack = this.Backpack.ToOriginalClass();
            entity.Inventory = this.Inventory.ToOriginalClass();
            entity.Weapon = this.Weapon.ToOriginalClass();
            HashSet<Mission> missions = new HashSet<Mission>();
            foreach (MissionDTO item in this.CompletedMissions)
            {
                missions.Add(item.ToOriginalClass());
            }
            entity.CompletedMissions = missions;
            return entity;
        }
    }
}