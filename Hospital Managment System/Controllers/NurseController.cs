using Hospital_Managment_System.Models;
using Hospital_Managment_System.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managment_System.Controllers
{
    public class NurseController : Controller
    {
        private readonly INurseService _nurseService;

        public NurseController(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        public IActionResult Index()
        {
            var nurses = _nurseService.GetAllNursesAsync();
            return View(nurses);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                _nurseService.AddNurse(nurse);
                return RedirectToAction("Index");
            }
            return View(nurse);
        }

        public IActionResult Edit(int id)
        {
            var nurse = _nurseService.GetNurseById(id);
            if (nurse == null) return NotFound();
            return View(nurse);
        }

        [HttpPost]
        public IActionResult Edit(Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                _nurseService.UpdateNurse(nurse);
                return RedirectToAction("Index");
            }
            return View(nurse);
        }

        public IActionResult Delete(int id)
        {
            var nurse = _nurseService.GetNurseById(id);
            if (nurse == null) return NotFound();
            return View(nurse);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _nurseService.DeleteNurse(id);
            return RedirectToAction("Index");
        }
    }
}
