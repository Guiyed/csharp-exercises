using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

       

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        //public IActionResult NewCheese(string name, string description = "")
        {
            /* Framework using Model Binding and creates and populate data qith the default constructor 
             * 
             * Cheese newCheese = new Cheese();
             * newCheese.Name = Request.get("name");
             * newCheese.Description = Request.get("description");
             * 
            
            // Constructor Kind Of
            /*
            Cheese newCheese = new Cheese() { 
                Description = description,
                Name = name
            };*/

            // Add the new cheese to my existing cheeses
            CheeseData.Add(newCheese);

            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/");
        }

        public IActionResult Edit(int cheeseId)
        {
            ViewBag.cheese = CheeseData.GetById(cheeseId);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int cheeseId, string name, string description)
        {

            Cheese cheeseToUpdate = CheeseData.GetById(cheeseId);
            cheeseToUpdate.Name = name;
            cheeseToUpdate.Description = description;

            return Redirect("/");
        }

    }
}
