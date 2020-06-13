using System;
using System.Collections.Generic;
using System.Linq;
using ItCareer.Database;
using ItCareer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItCareer.Controllers
{
    public class BreedController : Controller
    {
        private DogContext context;

        public BreedController(DogContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult ShowAllBreeds()
        {
            return View(GetAllBreeds());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateABreed(Breed breed)
        {
            this.context.Breeds.Add(breed);
            this.context.SaveChanges();

            return RedirectToAction("ShowAllBreeds");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var breed = GetBreed(id);

            return View(breed);
        }

        [HttpPost]
        public IActionResult EditABreed(int id, Breed breed)
        {
            var breedFromDb = GetBreed(id);

            breedFromDb.Name = breed.Name;

            this.context.SaveChanges();
            return RedirectToAction("ShowAllBreeds");
        }

        public IActionResult Delete(int id)
        {
            var breed = GetBreed(id);

            return View(breed);
        }

        [HttpPost]
        public IActionResult DeleteABreed(int id)
        {
            var breed = GetBreed(id);

            this.context.Remove(breed);
            this.context.SaveChanges();

            return RedirectToAction("ShowAllBreeds");
        }

        private IEnumerable<Breed> GetAllBreeds()
        {
            List<Breed> breeds = new List<Breed>(this.context.Breeds);

            return breeds.AsEnumerable();
        }

        private Breed GetBreed(int id)
        {
            return this.context.Breeds
                .FirstOrDefault(x => x.Id == id);
        }
    }
}