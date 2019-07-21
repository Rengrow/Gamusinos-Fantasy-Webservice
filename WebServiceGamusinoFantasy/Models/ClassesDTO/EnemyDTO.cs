using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class EnemyDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public long vitalityBase { get; set; }
        public long strengthBase { get; set; }
        public long resistanceBase { get; set; }
        public long speedBase { get; set; }
        public long experience { get; set; }
        public string rank { get; set; }

        public EnemyDTO(long id, string name, long vitalityBase, long strengthBase, long resistanceBase, long speedBase, long experience, string rank)
        {
            this.id = id;
            this.name = name;
            this.vitalityBase = vitalityBase;
            this.strengthBase = strengthBase;
            this.resistanceBase = resistanceBase;
            this.speedBase = speedBase;
            this.experience = experience;
            this.rank = rank;
        }

        public EnemyDTO(Enemy Enemy)
        {
            this.id = Enemy.id;
            this.name = Enemy.name;
            this.vitalityBase = Enemy.vitalityBase;
            this.strengthBase = Enemy.strengthBase;
            this.resistanceBase = Enemy.resistanceBase;
            this.speedBase = Enemy.speedBase;
            this.experience = Enemy.experience;
            this.rank = Enemy.rank;
        }

        public EnemyDTO() { }

        public Enemy ToOriginalClass()
        {
            Enemy entity = new Enemy();
            entity.id = this.id;
            entity.name = this.name;
            entity.vitalityBase = this.vitalityBase;
            entity.strengthBase = this.strengthBase;
            entity.resistanceBase = this.resistanceBase;
            entity.speedBase = this.speedBase;
            entity.experience = this.experience;
            entity.rank = this.rank;
            return entity;
        }

    }
    
}