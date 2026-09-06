using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.ViewModels;
namespace ZombieParty.Controllers
{

    public class ZombieTypeController : Controller
    {
        private BaseDonnees _baseDonnees { get; set; }
        public ZombieTypeController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            List<ZombieType> zombieTypesList = _baseDonnees.ZombieTypes.ToList();

            return View(zombieTypesList);
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                _baseDonnees.ZombieTypes.Add(zombieType);
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return this.RedirectToAction("Index");
            }

            return this.View(zombieType);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            List<Zombie> ZombieCategorie = _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id).ToList();

            ZombieTypeVM zombieTypeVM = new()
            {
                ZombieType = _baseDonnees.ZombieTypes.FirstOrDefault(zt => zt.Id == id),
                ZombiesList = ZombieCategorie,
                ZombiesCount = ZombieCategorie.Count(),
                PointsAverage = ZombieCategorie.Any() ? ZombieCategorie.Average(p => p.Point) : 0

            };

            zombieTypeVM.ZombieType = _baseDonnees.ZombieTypes.FirstOrDefault(zt => zt.Id == id);
            return View(zombieTypeVM);

        }

    }
}
