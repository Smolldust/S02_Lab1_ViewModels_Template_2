using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class WeaponController : Controller
    {
        private BaseDonnees _baseDonnees { get; set; }
        public WeaponController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }
        public IActionResult Index()
        {
            List<Weapon> weaponsList = _baseDonnees.Weapons.ToList();
            return View(weaponsList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                _baseDonnees.Weapons.Add(weapon);
                TempData["Success"] = $"{weapon.Name} added.";
                return this.RedirectToAction("Index");
            }

            return View(weapon);
        }

    }
}
