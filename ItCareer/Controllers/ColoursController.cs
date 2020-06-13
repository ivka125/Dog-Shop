using System;
using System.Collections.Generic;
using System.Linq;
using ItCareer.Database;
using ItCareer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItCareer.Controllers
{
    public class ColourController : Controller
    {
        private DogContext context;

        public ColourController(DogContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult ShowAllColours()
        {
            return View(GetAllColours());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAColour(Colour colour)
        {
            this.context.Colours.Add(colour);
            this.context.SaveChanges();

            return RedirectToAction("ShowAllColours");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var colour = GetColour(id);

            return View(colour);
        }

        [HttpPost]
        public IActionResult EditAColour(int id, Colour colour)
        {
            var colourFromDb = GetColour(id);

            colourFromDb.Name = colour.Name;

            this.context.SaveChanges();
            return RedirectToAction("ShowAllColours");
        }

        public IActionResult Delete(int id)
        {
            var colour = GetColour(id);

            return View(colour);
        }

        [HttpPost]
        public IActionResult DeleteAColour(int id)
        {
            var colour = GetColour(id);

            this.context.Remove(colour);
            this.context.SaveChanges();

            return RedirectToAction("ShowAllColours");
        }

        private IEnumerable<Colour> GetAllColours()
        {
            List<Colour> colours = new List<Colour>(this.context.Colours);

            return colours.AsEnumerable();
        }

        private Colour GetColour(int id)
        {
            return this.context.Colours
                .FirstOrDefault(x => x.Id == id);
        }
    }
}