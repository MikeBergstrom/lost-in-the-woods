using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lost.Models;
using lost.Factory;

namespace lost.Controllers
{
    public class HomeController : Controller
    {
        private readonly HikeFactory hikeFactory;
        public HomeController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            hikeFactory = new HikeFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.hikes = hikeFactory.GetHikes();
            return View();
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("addHike")]
        public IActionResult addHike(Hike hike){
            if(ModelState.IsValid){
                hikeFactory.Add(hike);
                return RedirectToAction("Index");
            } else {
                return View("add");
            }
        }
        [HttpGet]
        [Route("hikes/{id}")]
        public IActionResult Show(int id){
            ViewBag.hike = hikeFactory.Show(id);
            return View();
        }
        [HttpGet]
        [Route("length")]
        public IActionResult Length(){
            ViewBag.hikes = hikeFactory.Length();
            return View("index");
        }
        [HttpGet]
        [Route("elevation")]
        public IActionResult Elevation(){
            ViewBag.hikes = hikeFactory.Elevation();
            return View("index");
        }

    }
}
