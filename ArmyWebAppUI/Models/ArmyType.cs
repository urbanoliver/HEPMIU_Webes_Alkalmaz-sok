using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmyWebAppUI.Models
{
    [Table("ArmyType")]

    public class ArmyType
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]

        public string ArmyTypeName { get; set; }
        public List<Weapon> Weapons { get; set; }
    }
}
