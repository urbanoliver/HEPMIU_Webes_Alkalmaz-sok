namespace ArmyWebAppUI.Models.DTOs
{
    public class WeaponDisplayModel
    {
        public IEnumerable<Weapon> Weapons { get; set; }

        public IEnumerable<ArmyType> ArmyTypes { get; set; }

        public string STerm { get; set; } = "";

        public int ArmyTypeId { get; set; } = 0;
    }
}
