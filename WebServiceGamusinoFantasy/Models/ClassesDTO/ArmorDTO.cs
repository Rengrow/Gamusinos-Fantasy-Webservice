using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models.ClassesDTO
{
    public class ArmorDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long vitalityBonus { get; set; }
        public long resistanceBonus { get; set; }
        public long forceBonus { get; set; }
        public long speedBonus { get; set; }
        public long luckBonus { get; set; }
        public ICollection<Armor_CraftDTO> Armor_Craft { get; set; }

        public ArmorDTO(long id, string name, string description, long vitalityBonus, long resistanceBonus, long forceBonus, long speedBonus, long luckBonus, HashSet<Armor_CraftDTO> Armor_Craft)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.vitalityBonus = vitalityBonus;
            this.resistanceBonus = resistanceBonus;
            this.forceBonus = forceBonus;
            this.speedBonus = speedBonus;
            this.luckBonus = luckBonus;
            this.Armor_Craft = Armor_Craft;
        }

        public ArmorDTO(long id, string name, string description, long vitalityBonus, long resistanceBonus, long forceBonus, long speedBonus, long luckBonus)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.vitalityBonus = vitalityBonus;
            this.resistanceBonus = resistanceBonus;
            this.forceBonus = forceBonus;
            this.speedBonus = speedBonus;
            this.luckBonus = luckBonus;
            this.Armor_Craft = new HashSet<Armor_CraftDTO>();
        }

        public ArmorDTO(Armor armor)
        {
            this.id = armor.id;
            this.name = armor.name;
            this.description = armor.description;
            this.vitalityBonus = armor.vitalityBonus;
            this.resistanceBonus = armor.resistanceBonus;
            this.forceBonus = armor.forceBonus;
            this.speedBonus = armor.speedBonus;
            this.luckBonus = armor.luckBonus;
            ICollection<Armor_CraftDTO> collection = new HashSet<Armor_CraftDTO>();
            foreach (Armor_Craft item in armor.Armor_Craft)
            {
                collection.Add(new Armor_CraftDTO(item));
            }
            this.Armor_Craft = collection;
        }

        public ArmorDTO()
        {
            this.Armor_Craft = new HashSet<Armor_CraftDTO>();
        }

        public Armor ToOriginalClass()
        {
            Armor entity = new Armor();
            entity.id = this.id;
            entity.name = this.name;
            entity.description = this.description;
            entity.vitalityBonus = this.vitalityBonus;
            entity.resistanceBonus = this.resistanceBonus;
            entity.forceBonus = this.forceBonus;
            entity.speedBonus = this.speedBonus;
            entity.luckBonus = this.luckBonus;
            ICollection<Armor_Craft> collection = new HashSet<Armor_Craft>();
            foreach (Armor_CraftDTO item in this.Armor_Craft)
            {
                collection.Add(item.ToOriginalClass());
            }
            entity.Armor_Craft = collection;
            return entity;
        }
    }
}