using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class SelectedMissionDTO
    {
        public long Player_id { get; set; }
        public long Mission_id { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        [JsonIgnore]
        public PlayerDTO Player { get; set; }
        public MissionDTO Mission { get; set; }

        public SelectedMissionDTO(long Player_id, long Mission_id, decimal latitude, decimal longitude, PlayerDTO player, MissionDTO mission)
        {
            this.Player_id = Player_id;
            this.Mission_id = Mission_id;
            this.latitude = latitude;
            this.longitude = longitude;
            this.Player = player;
            this.Mission = mission;
        }

        public SelectedMissionDTO(long Player_id, long Mission_id, decimal latitude, decimal longitude)
        {
            this.Player_id = Player_id;
            this.Mission_id = Mission_id;
            this.latitude = latitude;
            this.longitude = longitude;
            this.Player = new PlayerDTO();
            this.Mission = new MissionDTO();
        }

        public SelectedMissionDTO(SelectedMission sm)
        {
            this.Player_id = sm.Player_id;
            this.Mission_id = sm.Mission_id;
            this.latitude = sm.latitude;
            this.longitude = sm.longitude;
            this.Player = new PlayerDTO(sm.Player);
            this.Mission = new MissionDTO(sm.Mission);
        }
        public SelectedMissionDTO()
        {

        }

        public SelectedMission ToOriginalClass()
        {
            SelectedMission entity = new SelectedMission();
            entity.Player_id = this.Player_id;
            entity.Mission_id = this.Mission_id;
            entity.latitude = this.latitude;
            entity.longitude = this.longitude;
            if (this.Player != null)
                entity.Player = this.Player.ToOriginalClass();
            if (this.Player != null)
                entity.Mission = this.Mission.ToOriginalClass();
            return entity;
        }
    }
}