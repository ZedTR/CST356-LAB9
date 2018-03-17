
using System.Collections.Generic;
using CST356_lab3.ViewModel;
using System.Linq;
using CST356_lab3.Data.Entities;
using CST356_lab3.Data;
using System.Web.Mvc;
using CST356_lab3.repository;
using CST356_lab3.Services;

namespace CST356_lab3.Controllers
{
    public class ClassesController : Controller
    {
        private readonly Iservice _Iservice;
        
        public ClassesController(Iservice Iservice)
        {
            _Iservice = Iservice;
        }
        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var Classes = _Iservice.GetClassesForUser(userId);

            return View(Classes);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewClassesModel  ClassViewModel)
        {
            if (ModelState.IsValid)
            {
                _Iservice.SaveClass(ClassViewModel);
                return RedirectToAction("List", new { UserId = ClassViewModel.UserId });
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var Class = _Iservice.GetClass(id);

            _Iservice.DeleteClass(id);

            return RedirectToAction("List", new { UserId = Class.UserId });
        }


    
    }
}
