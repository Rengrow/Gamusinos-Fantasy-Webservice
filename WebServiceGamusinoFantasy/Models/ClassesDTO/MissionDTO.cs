using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class MissionDTO
    {
        public long id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string rank { get; set; }
        public ICollection<EnemyAssignedToAMissionDTO> EnemyAssignedToAMissions { get; set; }
        public ICollection<RewardDTO> Rewards { get; set; }

        public MissionDTO(long id, string title, string description, string rank, HashSet<EnemyAssignedToAMissionDTO> EnemyAssignedToAMissions, HashSet<RewardDTO> Rewards)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.rank = rank;
            this.EnemyAssignedToAMissions = EnemyAssignedToAMissions;
            this.Rewards = Rewards;
        }

        public MissionDTO(long id, string title, string description, string rank)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.rank = rank;
            this.EnemyAssignedToAMissions = new HashSet<EnemyAssignedToAMissionDTO>();
            this.Rewards = new HashSet<RewardDTO>();
        }

        public MissionDTO(Mission mission)
        {
            this.id = mission.id;
            this.title = mission.title;
            this.description = mission.description;
            this.rank = mission.rank;
            int i = 0;
            bool parar = false;
            HashSet<EnemyAssignedToAMissionDTO> enemiesDTO = new HashSet<EnemyAssignedToAMissionDTO>();
            HashSet<RewardDTO> rewardsDTO = new HashSet<RewardDTO>();
            do
            {
                if (i < mission.EnemyAssignedToAMissions.Count)
                    enemiesDTO.Add(new EnemyAssignedToAMissionDTO(mission.EnemyAssignedToAMissions.ElementAt(i)));

                if (i < mission.Rewards.Count)
                    rewardsDTO.Add(new RewardDTO(mission.Rewards.ElementAt(i)));

                i++;

                if (mission.EnemyAssignedToAMissions.Count <= i && mission.Rewards.Count <= i)
                    parar = true;

            } while (!parar);

            this.EnemyAssignedToAMissions = enemiesDTO;
            this.Rewards = rewardsDTO;
        }

        public MissionDTO()
        {
            EnemyAssignedToAMissions = new HashSet<EnemyAssignedToAMissionDTO>();
            Rewards = new HashSet<RewardDTO>();
        }

        public Mission ToOriginalClass()
        {
            Mission entity = new Mission();
            entity.id = this.id;
            entity.title = this.title;
            entity.description = this.description;
            entity.rank = this.rank;
            int i = 0;
            bool parar = false;
            HashSet<EnemyAssignedToAMission> enemies = new HashSet<EnemyAssignedToAMission>();
            HashSet<Reward> rewards = new HashSet<Reward>();
            do
            {
                if (i < this.EnemyAssignedToAMissions.Count)
                    enemies.Add(this.EnemyAssignedToAMissions.ElementAt(i).ToOriginalClass());

                if (i < this.Rewards.Count)
                    rewards.Add(this.Rewards.ElementAt(i).ToOriginalClass());

                i++;

                if (this.EnemyAssignedToAMissions.Count <= i && this.Rewards.Count <= i)
                    parar = true;

            } while (!parar);

            entity.EnemyAssignedToAMissions = enemies;
            entity.Rewards = rewards;
            return entity;
        }

    }
}