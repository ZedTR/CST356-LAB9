/*
 Name: Zed Trzcinski
 Date: 2/9/2018
 Lab3
 
 */


using CST356_lab3.Data;
using CST356_lab3.Data.Entities;
using CST356_lab3.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;
using CST356_lab3.Services;
using CST356_lab3.repository;

namespace CST320_lab2.Controllers
{
    public class UserController : Controller
    {
        private readonly Iservice _userService;
        public UserController(Iservice userService)
        {    
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewUserModel user)
        {
           
            if (ModelState.IsValid)
            {
                _userService.SaveUser(user);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
   

        // GET: User
        public ActionResult Index()
        {

            var userViewModels = _userService.GetAllUsers();

            return View(userViewModels);

        }

        public ActionResult List()
        {
            var userViewModels = _userService.GetAllUsers();

            return View(userViewModels);
        }

       
        public ActionResult Details(int id)
        {

            var userViewModel = _userService.GetUser(id);

            return View(userViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(ViewUserModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(userViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            _userService.DeleteUser(id);

            return RedirectToAction("List");
        }
      

       

    
      

    }
}