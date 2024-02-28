using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ArmyWebAppUI.Models
{
    [Table("Weapon")]

    public class Weapon
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? WeaponName { get; set; }

        [Required]
        [MaxLength(40)]
        public string? ManufacturerName { get; set; }


        [Required]
        public double Price { get; set; }   

        public string? WeaponImage { get; set; }
        [Required]
        public int ArmyTypeId { get; set; }

        public ArmyType ArmyType { get; set; }

        public List<OrderDetail> OrderDetail{ get; set; }

        public List<CartDetail> CartDetail { get; set; }

        [NotMapped]

        public string ArmyTypeName { get; set; }   


    }
}

