using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class EnemyAssignedToAMissionDTO
    {
        public long Enemy_lvl { get; set; }
        public EnemyDTO Enemy { get; set; }

        public EnemyAssignedToAMissionDTO(long Enemy_lvl, Enemy Enemy)
        {
            this.Enemy_lvl = Enemy_lvl;
            this.Enemy = new EnemyDTO(Enemy);
        }

        public EnemyAssignedToAMissionDTO(long Enemy_lvl)
        {
            this.Enemy_lvl = Enemy_lvl;
            this.Enemy = new EnemyDTO();
        }

        public EnemyAssignedToAMissionDTO(EnemyAssignedToAMission EnemyAssignedToAMission)
        {
            this.Enemy_lvl = EnemyAssignedToAMission.Enemy_lvl;
            this.Enemy = new EnemyDTO(EnemyAssignedToAMission.Enemy);
        }

        public EnemyAssignedToAMissionDTO()
        {
            this.Enemy = new EnemyDTO();
        }

        public EnemyAssignedToAMission ToOriginalClass()
        {
            EnemyAssignedToAMission entity = new EnemyAssignedToAMission();
            entity.Enemy_lvl = this.Enemy_lvl;
            entity.Enemy = this.Enemy.ToOriginalClass();
            return entity;
        }
    }
}