using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebServiceGamusinoFantasy.Models;
using WebServiceGamusinoFantasy.Models.ClassesDTO;

namespace WebServiceGamusinoFantasy.Controllers
{ 
    public class GamusinoFantasyController : ApiController
    {
        // ------------------------------GET--------------------------------
        // GET: all armors
        [Route("api/allArmors")]
        public HttpResponseMessage PostGetAllArmors()
        {
            var armors = GamusinoRepository.GetAllArmors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, armors);
            return response;
        }

        // GET: all weapons
        [Route("api/allWeapons")]
        public HttpResponseMessage PostGetAllWeapons()
        {
            var weapons = GamusinoRepository.GetAllWeapons();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, weapons);
            return response;
        }


        /* GET: all users
        [Route("api/allUsers")]
        public HttpResponseMessage GetAllUsers()
        {
            var users = GamusinoRepository.GetAllUsers();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);
            return response;
        } */

        // GET: user by nick
        [Route("api/user/{nick}")]
        public HttpResponseMessage PostGetUserByNick(string nick)
        {
            var user = GamusinoRepository.GetUser(nick);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }

        // GET: 'Successfull' message if the user exists by nick
        [Route("api/userExists/{nick}")]
        public HttpResponseMessage PostGetUserExists(string nick)
        {
            var message = GamusinoRepository.UserExists(nick);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }

        // GET: coordinates by userId
        [Route("api/coordinates/{userId?}")]
        public HttpResponseMessage PostGetCoordinatesByUserId(long userId)
        {
            var coordinates = GamusinoRepository.GetCoordinateByUserId(userId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, coordinates);
            return response;
        }

        // GET: inventory items by playerId
        [Route("api/inventoryItem/{playerId?}")]
        public HttpResponseMessage PostGetInventoryItemByPlayerId(long playerId)
        {
            var inventory = GamusinoRepository.GetInventoryItemByPlayerId(playerId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, inventory);
            return response;
        }

        // GET: inventory by playerId
        [Route("api/inventoryAll/{playerId?}")]
        public HttpResponseMessage PostGetInventoryByPlayerId(long playerId)
        {
            var inventory = GamusinoRepository.GetInventoryByPlayerId(playerId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, inventory);
            return response;
        }

        // GET: armor by armorId
        [Route("api/armor/{armorId?}")]
        public HttpResponseMessage PostGetArmorByArmorId(long armorId)
        {
            var items = GamusinoRepository.GetArmorByArmorId(armorId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, items);
            return response;
        }

        // GET: items to craft an armor by armorId
        [Route("api/armorCraft/{armorId?}")]
        public HttpResponseMessage PostGetArmorCraftByArmorId(long armorId)
        {
            var items = GamusinoRepository.GetItemsToCraftArmorByArmorId(armorId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, items);
            return response;
        }

        // GET: weapon by weaponId
        [Route("api/weapon/{weaponId?}")]
        public HttpResponseMessage PostGetWeaponByWeaponId(long weaponId)
        {
            var items = GamusinoRepository.GetWeaponByWeaponId(weaponId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, items);
            return response;
        }

        // GET: items to craft a weapon by weaponId
        [Route("api/weaponCraft/{weaponId?}")]
        public HttpResponseMessage PostGetWeaponCraftByWeaponId(long weaponId)
        {
            var items = GamusinoRepository.GetItemsToCraftWeaponByWeaponId(weaponId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, items);
            return response;
        }

        // GET: armors from inventory by inventoryId
        [Route("api/inventoryArmors/{inventoryId?}")]
        public HttpResponseMessage PostGetArmorsByInventoryId(long inventoryId)
        {
            var armors = GamusinoRepository.GetArmorsByInventoryId(inventoryId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, armors);
            return response;
        }

        // GET: weapons from inventory by inventoryId
        [Route("api/inventoryWeapons/{inventoryId?}")]
        public HttpResponseMessage PostGetWeaponsByInventoryId(long inventoryId)
        {
            var weapons = GamusinoRepository.GetWeaponsByInventoryId(inventoryId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, weapons);
            return response;
        }

        // GET: Item by itemId
        [Route("api/item/{itemId?}")]
        public HttpResponseMessage PostGetItemById(long itemId)
        {
            var item = GamusinoRepository.GetItemById(itemId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, item);
            return response;
        }

        // GET: all missions
        [Route("api/allMissions")]
        public HttpResponseMessage PostGetAllMissions()
        {
            var missions = GamusinoRepository.GetAllMissions();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, missions);
            return response;
        }

        // GET: selected missions by playerId
        [Route("api/selectedMissions/{playerId?}")]
        public HttpResponseMessage PostGetSelectedMissionsByPlayerId(long playerId)
        {
            var selectedMissions = GamusinoRepository.GetMissionsByPlayerId(playerId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, selectedMissions);
            return response;
        }

        // GET: unselected missions by playerId
        [Route("api/unselectedMissions/{playerId?}/{rank}")]
        public HttpResponseMessage PostGetUnselectedMissionsByPlayerId(long playerId, string rank)
        {
            var unselectedMissions = GamusinoRepository.GetMissionsNoSelectedByPlayerIdAndRank(playerId, rank);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, unselectedMissions);
            return response;
        }

        // GET: rank by playerId
        [Route("api/playerRank/{playerId?}")]
        public HttpResponseMessage PostGetRankByPlayerId(long playerId)
        {
            var rank = GamusinoRepository.GetRankByPlayerId(playerId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rank);
            return response;
        }

        // GET: missions by rank
        [Route("api/missionsRank/{rank}")]
        public HttpResponseMessage PostGetMissionsByRank(string rank)
        {
            var missionsLocation = GamusinoRepository.GetMissionsByRank(rank);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, missionsLocation);
            return response;
        }

        // GET: missions same rank or superior by rank
        [Route("api/missionsRankSuperior/{rank}")]
        public HttpResponseMessage PostGetMissionsByRankSuperior(string rank)
        {
            var missionsLocation = GamusinoRepository.GetMissionsByRankSuperior(rank);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, missionsLocation);
            return response;
        }

        // GET: player (for android) by userId
        [Route("api/playerA/{userId?}")]
        public HttpResponseMessage PostGetPlayerAByUserId(long userId)
        {
            var player = GamusinoRepository.GetPlayerByUserId(userId, false);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, player);
            return response;
        }

        // GET: player (for desktop) by userId
        [Route("api/playerD/{userId?}")]
        public HttpResponseMessage PostGetPlayerDByUserId(long userId)
        {
            var player = GamusinoRepository.GetPlayerByUserId(userId, true);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, player);
            return response;
        }

        // GET: enemy by missionId
        [Route("api/enemyMission/{missionId?}")]
        public HttpResponseMessage PostGetEnemyAssignedByMissionId(long missionId)
        {
            var enemy = GamusinoRepository.GetEnemyAssignedByMissionId(missionId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, enemy);
            return response;
        }

        // GET: enemies by rank
        [Route("api/enemiesByRank/{rank}")]
        public HttpResponseMessage PostGetEnemiesByRank(string rank)
        {
            var enemy = GamusinoRepository.GetEnemiesByRank(rank);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, enemy);
            return response;
        }

        // GET: all enemies
        [Route("api/allEnemies")]
        public HttpResponseMessage PostGetAllEnemies()
        {
            var enemies = GamusinoRepository.GetAllEnemies();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, enemies);
            return response;
        }

        // GET: enemy by enemyId
        [Route("api/enemy/{enemyId?}")]
        public HttpResponseMessage PostGetEnemyByEnemyId(long enemyId)
        {
            var enemy = GamusinoRepository.GetEnemyByEnemyId(enemyId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, enemy);
            return response;
        }

        // GET: backpack items by backpackId
        [Route("api/backpack/{backpackId?}")]
        public HttpResponseMessage PostGetBackpackByBackpackId(long backpackId)
        {
            var backpack = GamusinoRepository.GetBackpackByBackpackId(backpackId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, backpack);
            return response;
        }


        // ----------------------------PUT----------------------------------
        // PUT: new quantity InventoryItem by player and item Id
        [Route("api/newInventoryItem/{playerId?}/{itemId?}/{itemQnt?}")]
        public HttpResponseMessage PutNewQuantityInventoryItemByPlayerAndItemId(long playerId, long itemId, long itemQnt)
        {
            var message = GamusinoRepository.UpdateQuantityInventoryItemByPlayerId(playerId, itemId, itemQnt);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }

        // PUT: new quantity backpackItem by player and item Id
        [Route("api/newBackpackItem/{playerId?}/{itemId?}/{itemQnt?}")]
        public HttpResponseMessage PutNewQuantityBackpackItemByPlayerAndItemId(long playerId, long itemId, long itemQnt)
        {
            var message = GamusinoRepository.UpdateQuantityBackpackItemByPlayerId(playerId, itemId, itemQnt);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }

        // PUT: new password by recover code
        [Route("api/newPassword/{recoverCode}/{password}")]
        public HttpResponseMessage PutNewPasswordByRecoverCode(string recoverCode, string password)
        {
            var newRecoverCode = GamusinoRepository.UpdateNewPasswordByRecoverCode(recoverCode, password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, newRecoverCode);
            return response;
        }

        // PUT: update attributes by playerId
        [Route("api/updateAttributes")]
        public HttpResponseMessage PutNewAttributes([FromBody] PlayerDTO player)
        {
            var message = GamusinoRepository.UpdateAttributes(player);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }

        // PUT: backpackItems to InventoryItems by playerId
        [Route("api/backpackToInventory/{playerId?}")]
        public HttpResponseMessage PutBackpackItemsToInventoryItems(long playerId)
        {
            var message = GamusinoRepository.BackpackToInventory(playerId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }


        // -----------------------------POST----------------------------------
        // POST: inventory items by player
        [Route("api/inventoryItems/{playerId?}")]
        public HttpResponseMessage PostNewInventoryItemsByPlayerId(long playerId, [FromBody]List<Inventory_ItemsDTO> items)
        {
            var message = GamusinoRepository.InsertNewInventoryItemsByPlayerId(playerId, items);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }

        // POST: new armor by inventory and armor Id
        [Route("api/newArmor/{inventoryId?}/{armorId?}")]
        public HttpResponseMessage PostNewArmorByInventoryAndArmorId(long inventoryId, long armorId)
        {
            var message = GamusinoRepository.InsertNewArmorByInventoryId(inventoryId, armorId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }

        // POST: new weapon by inventory and weapon Id
        [Route("api/newWeapon/{inventoryId?}/{weaponId?}")]
        public HttpResponseMessage PostNewWeaponByInventoryAndWeaponId(long inventoryId, long weaponId)
        {
            var message = GamusinoRepository.InsertNewWeaponByInventoryId(inventoryId, weaponId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }
        
        // POST: backpackItem by player and item Id
        [Route("api/backpackItems/{playerId?}")]
        public HttpResponseMessage PostNewBackpackItemsByPlayerAndItemId(long playerId, [FromBody]List<Backpack_ItemsDTO> items)
        {
            var message = GamusinoRepository.InsertnewBackpackItemsByPlayerId(playerId, items);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }

        // POST: new accepted mission by player and mission Id
        [Route("api/newMission/{playerId?}")]
        public HttpResponseMessage PostNewAcceptedMissionByPlayerId(long playerId, [FromBody]SelectedMissionDTO mission)
        {
            var acceptedMission = GamusinoRepository.InsertNewAcceptedMissionByPlayerId(playerId, mission);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, acceptedMission);
            return response;
        }

        // POST: new User by UserDTO
        [Route("api/newUser")]
        public HttpResponseMessage PostNewUserByUserDTO([FromBody] UserDTO user)
        {
            var newUser = GamusinoRepository.InsertNewUser(user);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, newUser);
            return response;
        }


        // ----------------------------DELETE---------------------------------
        // DELETE: a selected mission by player and mission Id
        [Route("api/declineMission/{playerId?}/{missionId?}")]
        public HttpResponseMessage DeleteSelectedMissionByPlayerAndMissionId(long playerId, long missionId)
        {
            GamusinoRepository.DeleteSelectedMissionByPlayerId(playerId, missionId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // DELETE: all backpack items by playerId
        [Route("api/deleteAllBackpackItems/{playerId?}")]
        public HttpResponseMessage DeleteAllBackpackItemsByPlayerId(long playerId)
        {
            GamusinoRepository.DeleteAllBackPackByPlayerId(playerId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // DELETE: backpackItem by player and item Id
        [Route("api/deleteInventoryItem/{playerId?}/{itemId?}")]
        public HttpResponseMessage DeleteInventoryItemByPlayerId(long playerId, long itemId)
        {
            GamusinoRepository.DeleteInventoryItemByPlayerId(playerId, itemId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // DELETE: backpackItem by player and item Id
        [Route("api/deleteBackpackItem/{playerId?}/{itemId?}")]
        public HttpResponseMessage DeleteBackpackItemByPlayerId(long playerId, long itemId)
        {
            GamusinoRepository.DeleteBackpackItemByPlayerId(playerId, itemId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}