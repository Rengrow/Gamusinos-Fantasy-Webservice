using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class WeaponDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long vitalityBonus { get; set; }
        public long resistanceBonus { get; set; }
        public long forceBonus { get; set; }
        public long speedBonus { get; set; }
        public long luckBonus { get; set; }
        public ICollection<Weapon_CraftDTO> Weapon_Craft { get; set; }

        public WeaponDTO(long id, string name, string description, long vitalityBonus, long resistanceBonus, long forceBonus, long speedBonus, long luckBonus, HashSet<Weapon_CraftDTO> Weapon_Craft)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.vitalityBonus = vitalityBonus;
            this.resistanceBonus = resistanceBonus;
            this.forceBonus = forceBonus;
            this.speedBonus = speedBonus;
            this.luckBonus = luckBonus;
            this.Weapon_Craft = Weapon_Craft;
        }

        public WeaponDTO(long id, string name, string description, long vitalityBonus, long resistanceBonus, long forceBonus, long speedBonus, long luckBonus)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.vitalityBonus = vitalityBonus;
            this.resistanceBonus = resistanceBonus;
            this.forceBonus = forceBonus;
            this.speedBonus = speedBonus;
            this.luckBonus = luckBonus;
            this.Weapon_Craft = new HashSet<Weapon_CraftDTO>();
        }

        public WeaponDTO(Weapon weapon)
        {
            this.id = weapon.id;
            this.name = weapon.name;
            this.description = weapon.description;
            this.vitalityBonus = weapon.vitalityBonus;
            this.resistanceBonus = weapon.resistanceBonus;
            this.forceBonus = weapon.forceBonus;
            this.speedBonus = weapon.speedBonus;
            this.luckBonus = weapon.luckBonus;
            ICollection<Weapon_CraftDTO> Weapon_Craft = new HashSet<Weapon_CraftDTO>();
            foreach (Weapon_Craft item in weapon.Weapon_Craft)
            {
                Weapon_Craft.Add(new Weapon_CraftDTO(item));
            }
            this.Weapon_Craft = Weapon_Craft;
        }

        public WeaponDTO()
        {
            this.Weapon_Craft = new HashSet<Weapon_CraftDTO>();
        }

        public Weapon ToOriginalClass()
        {
            Weapon entity = new Weapon();
            entity.id = this.id;
            entity.name = this.name;
            entity.description = this.description;
            entity.vitalityBonus = this.vitalityBonus;
            entity.resistanceBonus = this.resistanceBonus;
            entity.forceBonus = this.forceBonus;
            entity.speedBonus = this.speedBonus;
            entity.luckBonus = this.luckBonus;
            ICollection<Weapon_Craft> Weapon_Craft = new HashSet<Weapon_Craft>();
            foreach (Weapon_CraftDTO item in this.Weapon_Craft)
            {
                Weapon_Craft.Add(item.ToOriginalClass());
            }
            entity.Weapon_Craft = Weapon_Craft;
            return entity;
        }
    }
}