using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class CombatLogDTO
    {
        public long id { get; set; }
        public long Player_lvl { get; set; }
        public long Enemy_id { get; set; }
        public long Enemy_lvl { get; set; }

        public CombatLogDTO(long id, long Player_lvl, long Enemy_id, long Enemy_lvl)
        {
            this.id = id;
            this.Player_lvl = Player_lvl;
            this.Enemy_id = Enemy_id;
            this.Enemy_lvl = Enemy_lvl;
        }

        public CombatLogDTO()
        {

        }

        public CombatLog ToOriginalClass()
        {
            CombatLog entity = new CombatLog();
            entity.id = this.id;
            entity.Player_lvl = this.Player_lvl;
            entity.Enemy_id = this.Enemy_id;
            entity.Enemy_lvl = this.Enemy_lvl;
            return entity;
        }
    }
}