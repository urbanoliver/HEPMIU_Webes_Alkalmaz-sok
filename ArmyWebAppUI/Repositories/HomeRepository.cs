
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace ArmyWebAppUI.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ArmyType>> ArmyTypes()
        {
            return await _db.ArmyTypes.ToListAsync();
        }



        public async Task<IEnumerable<Weapon>> GetWeapons(string sTerm="", int armytypeId=0) {

            sTerm=sTerm.ToLower();

            IEnumerable<Weapon> weapons = await (from weapon in _db.Weapons
                           join armytype in _db.ArmyTypes
                           on weapon.ArmyTypeId equals armytype.Id

                           where string.IsNullOrWhiteSpace(sTerm) ||(weapon!=null && weapon.WeaponName.ToLower().StartsWith(sTerm))

                           select new Weapon
                           {
                               Id = weapon.Id,
                               WeaponImage = weapon.WeaponImage,
                               ManufacturerName = weapon.ManufacturerName,
                               WeaponName = weapon.WeaponName,
                               ArmyTypeId = weapon.ArmyTypeId,
                               Price = weapon.Price,
                               ArmyTypeName = armytype.ArmyTypeName,
                           }
                           ).ToListAsync();

            if (armytypeId > 0)
            {
                weapons = weapons.Where(a => a.ArmyTypeId == armytypeId).ToList(); 
            }

            return weapons;
        }

    }
}
