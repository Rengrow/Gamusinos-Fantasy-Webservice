using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class UserDTO
    {
        public long id { get; set; }
        public string nick { get; set; }
        public string password { get; set; }
        public string recoverCode { get; set; }
        public DateTime? lastLogin { get; set; }
        public byte? online { get; set; }
        public long Player_id { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }

        public UserDTO(long id, string nick, string password, string recoverCode, DateTime lastLogin, byte online, long Player_id, decimal latitude, decimal longitude)
        {
            this.id = id;
            this.nick = nick;
            this.password = password;
            this.recoverCode = recoverCode;
            this.lastLogin = lastLogin;
            this.online = online;
            this.Player_id = Player_id;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public UserDTO(User user)
        {
            this.id = user.id;
            this.nick = user.nick;
            this.password = user.password;
            this.recoverCode = user.recoverCode;
            this.lastLogin = user.lastLogin;
            this.online = user.online;
            this.Player_id = user.Player_id;
            this.latitude = user.latitude;
            this.longitude = user.longitude;
        }

        public UserDTO()
        {

        }

        public User ToOriginalClass()
        {
            User entity = new User();
            entity.id = this.id;
            entity.nick = this.nick;
            entity.password = this.password;
            entity.recoverCode = this.recoverCode;
            entity.lastLogin = this.lastLogin;
            entity.online = this.online;
            entity.Player_id = this.Player_id;
            entity.latitude = this.latitude;
            entity.longitude = this.longitude;
            return entity;
        }
    }
}