using GamusinosProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebServiceGamusinoFantasy.Models;
using WebServiceGamusinoFantasy.Models.ClassesDTO;
using WebServiceGamusinoFantasy.Models.Tools;

namespace WebServiceGamusinoFantasy.Controllers
{
    public class GamusinoRepository
    {
        private static GamusinosFantasyEntities db = new GamusinosFantasyEntities();

        // ---------------------GET------------------------

        public static List<ArmorDTO> GetAllArmors()
        {
            List<Armor> allArmors = db.Armors.ToList();
            List<ArmorDTO> collection = new List<ArmorDTO>();
            foreach (Armor item in allArmors)
            {
                collection.Add(new ArmorDTO(item));
            }
            return collection;
        }

        public static List<WeaponDTO> GetAllWeapons()
        {
            List<Weapon> allWeapons = db.Weapons.ToList();
            List<WeaponDTO> collection = new List<WeaponDTO>();
            foreach (Weapon item in allWeapons)
            {
                collection.Add(new WeaponDTO(item));
            }
            return collection;
        }

        public static List<UserDTO> GetAllUsers()
        {
            List<User> allUsers = db.Users.ToList();
            List<UserDTO> collection = new List<UserDTO>();
            foreach (User item in allUsers)
            {
                collection.Add(new UserDTO(item));
            }
            return collection;
        }

        public static Response UserExists(string nick)
        {
            Response response = new Response();
            response.message = "Error";
            List<User> allUsers = db.Users.ToList();
            foreach (User user in allUsers)
            {
                if (user.nick.Equals(nick))
                {
                    response.message = "Successfull";
                }
            }
            return response;
        }

        public static UserDTO GetUser(string nick)
        {
            return new UserDTO(db.Users.Where(x => x.nick.Equals(nick)).SingleOrDefault());
        }

        public static Coordinate GetCoordinateByUserId(long userId)
        {
            User user = db.Users.Where(u => u.id == userId).SingleOrDefault();
            return new Coordinate(Convert.ToDouble(user.latitude), Convert.ToDouble(user.longitude));
        }

        public static List<Inventory_ItemsDTO> GetInventoryItemByPlayerId(long playerId)
        {
            List<Inventory_Items> inventory = db.Players.Where(x => x.id == playerId).Select(x => x.Inventory).SingleOrDefault().Inventory_Items.ToList();
            List<Inventory_ItemsDTO> collection = new List<Inventory_ItemsDTO>();
            foreach (Inventory_Items item in inventory)
            {
                collection.Add(new Inventory_ItemsDTO(item));
            }
            return collection;
        }

        public static InventoryDTO GetInventoryByPlayerId(long playerId)
        {
            return new InventoryDTO(db.Players.Where(x => x.id == playerId).Select(x => x.Inventory).SingleOrDefault());
        }

        public static List<Armor_CraftDTO> GetItemsToCraftArmorByArmorId(long armorId)
        {
            List<Armor_Craft> itemsCraft = db.Armor_Craft.Where(x => x.Armor_id == armorId).ToList();
            List<Armor_CraftDTO> collection = new List<Armor_CraftDTO>();
            foreach (Armor_Craft item in itemsCraft)
            {
                collection.Add(new Armor_CraftDTO(item));
            }
            return collection;
        }

        public static List<Weapon_CraftDTO> GetItemsToCraftWeaponByWeaponId(long weaponId)
        {
            List<Weapon_Craft> itemsCraft = db.Weapon_Craft.Where(x => x.Weapon_id == weaponId).ToList();
            List<Weapon_CraftDTO> collection = new List<Weapon_CraftDTO>();
            foreach (Weapon_Craft item in itemsCraft)
            {
                collection.Add(new Weapon_CraftDTO(item));
            }
            return collection;
        }

        public static List<ArmorDTO> GetArmorsByInventoryId(long inventoryId)
        {
            Player player = db.Players.Where(x => x.Inventory_id == inventoryId).SingleOrDefault();
            List<Armor> armors = player.Inventory.Armors.ToList();
            List<ArmorDTO> collection = new List<ArmorDTO>();
            foreach (Armor item in armors)
            {
                collection.Add(new ArmorDTO(item));
            }
            return collection;
        }

        public static List<WeaponDTO> GetWeaponsByInventoryId(long inventoryId)
        {
            Player player = db.Players.Where(x => x.Inventory_id == inventoryId).SingleOrDefault();
            List<Weapon> weapons = player.Inventory.Weapons.ToList();
            List<WeaponDTO> collection = new List<WeaponDTO>();
            foreach (Weapon item in weapons)
            {
                collection.Add(new WeaponDTO(item));
            }
            return collection;
        }

        public static ItemDTO GetItemById(long itemId)
        {
            return new ItemDTO(db.Items.Where(x => x.id == itemId).SingleOrDefault());
        }

        public static ArmorDTO GetArmorByArmorId(long armorId)
        {
            return new ArmorDTO(db.Armors.Where(x => x.id == armorId).SingleOrDefault());
        }

        public static WeaponDTO GetWeaponByWeaponId(long weaponId)
        {
            return new WeaponDTO(db.Weapons.Where(x => x.id == weaponId).SingleOrDefault());
        }

        public static List<MissionDTO> GetAllMissions()
        {
            List<Mission> allMissions = db.Missions.ToList();
            List<MissionDTO> collection = new List<MissionDTO>();
            foreach (Mission item in allMissions)
            {
                collection.Add(new MissionDTO(item));
            }
            return collection;
        }

        public static List<SelectedMissionDTO> GetMissionsByPlayerId(long playerId)
        {
            List<SelectedMission> missions = db.SelectedMissions.Where(x => x.Player_id == playerId).OrderBy(m => m.Mission.title).ToList();
            List<SelectedMissionDTO> collection = new List<SelectedMissionDTO>();
            foreach (SelectedMission item in missions)
            {
                collection.Add(new SelectedMissionDTO(item));
            }
            return collection;
        }

        public static List<MissionDTO> GetMissionsByRank(string rank)
        {
            List<Mission> missions = db.Missions.Where(x => x.rank.Equals(rank)).OrderBy(m => m.title).ToList();
            List<MissionDTO> collection = new List<MissionDTO>();
            foreach (Mission item in missions)
            {
                collection.Add(new MissionDTO(item));
            }
            return collection;
        }

        public static List<MissionDTO> GetMissionsByRankSuperior(string rank)
        {
            List<Mission> missions = db.Missions.Where(x => x.rank.CompareTo(rank) >= 0).OrderBy(m => m.title).ToList();
            List<MissionDTO> collection = new List<MissionDTO>();
            foreach (Mission item in missions)
            {
                collection.Add(new MissionDTO(item));
            }
            return collection;
        }

        public static PlayerDTO GetPlayerByUserId(long userId, bool show)
        {
            PlayerDTO player = new PlayerDTO(db.Users.Select(x => x.Player).Where(x => x.id == userId).SingleOrDefault());
            player.SerializeVirtualProperties = show;
            return player;  
        }

        public static string GetRankByPlayerId(long player_id)
        {
            string rank = db.Players.Where(x => x.id == player_id).Select(x => x.rank).SingleOrDefault();
            return rank;
        }


        public static List<MissionDTO> GetMissionsNoSelectedByPlayerIdAndRank(long id, string rank)
        {
            Player player = db.Players.Where(p => p.id == id).SingleOrDefault();
            List<MissionDTO> AllMissions = GetMissionsByRank(rank);
            List<SelectedMissionDTO> MissionsAccepted = GetMissionsByPlayerId(player.id);

            foreach (SelectedMissionDTO mission in MissionsAccepted)
            {
                AllMissions.Remove(AllMissions.Where(m => m.id == mission.Mission_id).FirstOrDefault());
            }

            return AllMissions.ToList();
        }
 
        public static EnemyDTO GetEnemyAssignedByMissionId(long missionId)
        {
            return new EnemyDTO(db.EnemyAssignedToAMissions.Where(x => x.Mission_id == missionId).Select(x => x.Enemy).SingleOrDefault());
        }

        public static List<EnemyDTO> GetEnemiesByRank(string rank)
        {
            List<Enemy> enemies = db.Enemies.Where(x => x.rank.CompareTo(rank) >= 0).ToList();
            List<EnemyDTO> enemiesDTO = new List<EnemyDTO>();

            foreach (Enemy item in enemies)
            {
                enemiesDTO.Add(new EnemyDTO(item));
            }
            return enemiesDTO;
        }

        public static List<EnemyDTO> GetAllEnemies()
        {
            List<Enemy> enemies = db.Enemies.ToList();
            List<EnemyDTO> collection = new List<EnemyDTO>();
            foreach (Enemy item in enemies)
            {
                collection.Add(new EnemyDTO(item));
            }
            return collection;
        }

        public static EnemyDTO GetEnemyByEnemyId(long enemyId)
        {
            return new EnemyDTO(db.Enemies.Where(x => x.id == enemyId).SingleOrDefault());
        }

        public static List<Backpack_ItemsDTO> GetBackpackByBackpackId(long backpackId)
        {
            List<Backpack_Items> backpackItems = db.Backpack_Items.Where(i => i.Backpack_id == backpackId).ToList();
            List<Backpack_ItemsDTO> collection = new List<Backpack_ItemsDTO>();
            foreach (Backpack_Items item in backpackItems)
            {
                collection.Add(new Backpack_ItemsDTO(item));
            }
            return collection;
        }




        // ---------------------PUT------------------------

        public static Response UpdateQuantityInventoryItemByPlayerId(long playerId, long itemId, long quantityItem)
        {
            try
            {
                Player player = db.Players.Where(x => x.id == playerId).SingleOrDefault();
                Inventory_Items inventoryItem = player.Inventory.Inventory_Items.Where(x => x.Item_id == itemId).SingleOrDefault();
                if (inventoryItem == null)
                {
                    inventoryItem = new Inventory_Items();
                    inventoryItem.Item = db.Items.Where(i => i.id == itemId).SingleOrDefault();
                    player.Inventory.Inventory_Items.Add(inventoryItem);
                }
                inventoryItem.Quantity = quantityItem;
                if (inventoryItem.Quantity <= 0)
                {
                    DeleteInventoryItemByPlayerId(playerId, itemId);
                }

                db.SaveChanges();
                return new Response("Sucessful");
            }
            catch (Exception e)
            {
                return new Response("Error");
            }
        }

        public static Response UpdateQuantityBackpackItemByPlayerId(long playerId, long itemId, long quantityItem)
        {
            try
            {
                Player player = db.Players.Where(x => x.id == playerId).SingleOrDefault();
                Backpack_Items backpackItem = player.Backpack.Backpack_Items.Where(x => x.Item_id == itemId).SingleOrDefault();
                if (backpackItem == null)
                {
                    backpackItem = new Backpack_Items();
                    backpackItem.Item = db.Items.Where(x => x.id == itemId).SingleOrDefault();
                    player.Backpack.Backpack_Items.Add(backpackItem);
                }
                backpackItem.Quantity = quantityItem;
                if (backpackItem.Quantity <= 0)
                {
                    DeleteBackpackItemByPlayerId(playerId, itemId);
                }

                db.SaveChanges();
                return new Response("Sucessful");
            }
            catch (Exception e)
            {
                return new Response("Error");
            }
        }

        public static string UpdateNewPasswordByRecoverCode(string recoverCode, string password)
        {
            string newRecoverCode = RecoverCode.GenerateRecuperationCode(10);
            try
            {
                User user = db.Users.Where(x => x.recoverCode.Equals(recoverCode)).SingleOrDefault();

                if (user != null)
                {
                    user.password = SecurePasswordHasher.Hash(password);
                    user.recoverCode = newRecoverCode;

                    db.SaveChanges();
                }

                return newRecoverCode;
            }
            catch (Exception e)
            {
                return newRecoverCode;
            }
        }

        public static Response UpdateAttributes(PlayerDTO newPlayer)
        {
            try
            {
                Player player = db.Players.Where(x => x.id == newPlayer.id).SingleOrDefault();

                if (player != null)
                {
                    player.vitality = newPlayer.vitality;
                    player.force = newPlayer.force;
                    player.resistance = newPlayer.resistance;
                    player.speed = newPlayer.speed;
                    player.luck = newPlayer.luck;
                    player.Armor = db.Armors.Where(a => a.id == newPlayer.Armor_id).SingleOrDefault();
                    player.Weapon = db.Weapons.Where(a => a.id == newPlayer.Weapon_id).SingleOrDefault();
                    db.SaveChanges();
                }

                return new Response("Successful");
            }
            catch (Exception e)
            {
                return new Response("Error");
            }
        }

        public static Response BackpackToInventory(long playerId)
        {
            List<Backpack_Items> items = db.Players.Where(u => u.id == playerId).FirstOrDefault().Backpack.Backpack_Items.ToList();
            if (items.Count > 0)
            {
                List<Inventory_Items> inventory = db.Players.Where(u => u.id == playerId).FirstOrDefault().Inventory.Inventory_Items.ToList();
                foreach (Backpack_Items bItem in items)
                {
                    Inventory_Items item = inventory.Where(i => i.Item_id == bItem.Item_id).FirstOrDefault();
                    if (item != null)
                    {
                        item.Quantity += bItem.Quantity;
                    }
                    else
                    {
                        Inventory_Items newItem = new Inventory_Items();
                        newItem.Item = bItem.Item;
                        newItem.Quantity = bItem.Quantity;
                        db.Players.Where(u => u.id == playerId).FirstOrDefault().Inventory.Inventory_Items.Add(newItem);
                    }
                    db.Backpack_Items.Remove(bItem);
                }
                db.SaveChanges();
                return new Response("Successfull");
            }
            return new Response("Empty");
        }



        // ---------------------POST------------------------

        public static Response InsertNewInventoryItemsByPlayerId(long playerId, List<Inventory_ItemsDTO> items)
        {
            try
            {
                Inventory playerInventory = db.Players.Where(x => x.id == playerId).SingleOrDefault().Inventory;

                foreach (Inventory_ItemsDTO item in items)
                {
                    if (playerInventory.Inventory_Items.Any(i => i.Item_id == item.Item_id))
                    {
                        playerInventory.Inventory_Items.Where(i => i.Item_id == item.Item_id).FirstOrDefault().Quantity += item.Quantity;
                    }
                    else
                    {
                        Inventory_Items newItem = new Inventory_Items();

                        newItem.Item = db.Items.Where(i => i.id == item.Item_id).FirstOrDefault();
                        newItem.Quantity = item.Quantity;

                        playerInventory.Inventory_Items.Add(newItem);
                    }
                }
                db.SaveChanges();
                return new Response("Successfull");
            }
            catch (Exception e)
            {
                return new Response("Error");
            }
        }

        public static Response InsertNewArmorByInventoryId(long inventoryId, long armorId)
        {
            try
            {
                Armor armor = db.Armors.Where(x => x.id == armorId).SingleOrDefault();
                Inventory inventory = db.Inventories.Where(x => x.id == inventoryId).SingleOrDefault();
                inventory.Armors.Add(armor);
                db.SaveChanges();
                return new Response("Sucessful");
            }
            catch (Exception e)
            {
                return new Response("Error");
            }
        }

        public static Response InsertNewWeaponByInventoryId(long inventoryId, long weaponId)
        {
            try
            {
                Weapon weapon = db.Weapons.Where(x => x.id == weaponId).SingleOrDefault();
                Inventory inventory = db.Inventories.Where(x => x.id == inventoryId).SingleOrDefault();
                inventory.Weapons.Add(weapon);
                db.SaveChanges();
                return new Response("Sucessful");
            }
            catch (Exception e)
            {
                return new Response("Error");
            }
        }

        public static Response InsertnewBackpackItemsByPlayerId(long playerId, List<Backpack_ItemsDTO> items)
        {
            try
            {
                Backpack playerBackpack = db.Players.Where(x => x.id == playerId).SingleOrDefault().Backpack;

                foreach (Backpack_ItemsDTO item in items)
                {
                    if (playerBackpack.Backpack_Items.Any(i => i.Item_id == item.Item_id))
                    {
                        playerBackpack.Backpack_Items.Where(i => i.Item_id == item.Item_id).FirstOrDefault().Quantity += item.Quantity;
                    }
                    else
                    {
                        Backpack_Items newItem = new Backpack_Items();

                        newItem.Item = db.Items.Where(i => i.id == item.Item_id).FirstOrDefault();
                        newItem.Quantity = item.Quantity;

                        playerBackpack.Backpack_Items.Add(newItem);
                    }
                }
                db.SaveChanges();
                return new Response("Successfull");
            }
            catch (Exception e)
            {
                return new Response("Error");
            }
        }

        public static Response InsertNewAcceptedMissionByPlayerId(long playerId, SelectedMissionDTO mission)
        {
            try
            {
                Player player = db.Players.Where(x => x.id == playerId).SingleOrDefault();

                player.SelectedMissions.Add(mission.ToOriginalClass());
                db.SaveChanges();
                return new Response("Successfull");
            }
            catch (Exception e)
            {
                return new Response("Error");
            }
        }

        public static User InsertNewUser(UserDTO user)
        {

            User newUser = user.ToOriginalClass();

            newUser.password = SecurePasswordHasher.Hash(user.password);
            newUser.recoverCode = RecoverCode.GenerateRecuperationCode(10);

            newUser.Player = new Player();
            newUser.Player.vitality = 20;
            newUser.Player.force = 5;
            newUser.Player.resistance = 5;
            newUser.Player.speed = 5;
            newUser.Player.luck = 1;
            newUser.Player.rank = "E";

            newUser.Player.Inventory = new Inventory();
            newUser.Player.Backpack = new Backpack();
            Armor defaultArmor = db.Armors.Where(w => w.id == 1).FirstOrDefault();
            Weapon defaultWeapon = db.Weapons.Where(w => w.id == 1).FirstOrDefault();
            newUser.Player.Weapon = defaultWeapon;
            newUser.Player.Armor = defaultArmor;
            newUser.Player.Inventory.Armors.Add(defaultArmor);
            newUser.Player.Inventory.Weapons.Add(defaultWeapon);

            db.Users.Add(newUser);
            db.SaveChanges();
            return newUser;
        }



        // ---------------------DELETE------------------------

        public static void DeleteSelectedMissionByPlayerId(long playerId, long missionId)
        {
            SelectedMission mission = db.SelectedMissions.Where(x => x.Mission_id == missionId && x.Player_id == playerId).SingleOrDefault();
            Player player = db.Players.Where(x => x.id == playerId).SingleOrDefault();
            if (mission != null)
            {
                player.SelectedMissions.Remove(mission);
                db.SaveChanges();
            }
        }

        public static void DeleteAllBackPackByPlayerId(long playerId)
        {
            List<Backpack_Items> playerBackpack = db.Players.Where(x => x.id == playerId).SingleOrDefault().Backpack.Backpack_Items.ToList();

            foreach (Backpack_Items item in playerBackpack)
            {
                db.Backpack_Items.Remove(item);
            }
        }

        public static void DeleteInventoryItemByPlayerId(long playerId, long itemId)
        {
            Player player = db.Players.Where(x => x.id == playerId).SingleOrDefault();
            Inventory_Items item = player.Inventory.Inventory_Items.Where(x => x.Item_id == itemId).SingleOrDefault();
            if (item != null)
            {
                player.Inventory.Inventory_Items.Remove(item);
                db.SaveChanges();
            }
        }

        public static void DeleteBackpackItemByPlayerId(long playerId, long itemId)
        {
            Player player = db.Players.Where(x => x.id == playerId).SingleOrDefault();
            Backpack_Items item = player.Backpack.Backpack_Items.Where(x => x.Item_id == itemId).SingleOrDefault();
            if (item != null)
            {
                player.Backpack.Backpack_Items.Remove(item);
                db.SaveChanges();
            }
        }
    }
}