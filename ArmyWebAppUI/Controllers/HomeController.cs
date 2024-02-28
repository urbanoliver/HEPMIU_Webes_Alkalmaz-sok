using ArmyWebAppUI.Models;
using ArmyWebAppUI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArmyWebAppUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(string sTerm="", int armytypeID=0)
        {
            

            IEnumerable<Weapon> weapons = await _homeRepository.GetWeapons(sTerm,armytypeID);

            IEnumerable<ArmyType> armytypes = await _homeRepository.ArmyTypes();

            WeaponDisplayModel weaponModel = new WeaponDisplayModel
            {
                Weapons = weapons,
                ArmyTypes = armytypes,
                STerm = sTerm,
                ArmyTypeId = armytypeID


            };

            return View(weaponModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
