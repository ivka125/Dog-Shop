using System;
using System.Collections.Generic;
using System.Linq;
using ItCareer.Database;
using ItCareer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItCareer.Controllers
{
    public class ShopController : Controller
    {
        private DogContext context;

        public ShopController(DogContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult ShowAllDogs()
        {
            return View(GetAllDogies());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateADog(DogDto dogDto)
        {
            Dog dog = new Dog();

            dog.Name = dogDto.Name;
            dog.Age = dogDto.Age;
            dog.Breed = GetBreed(dogDto.BreedName);
            dog.Colour = GetColour(dogDto.ColourName);

            this.context.Dogs.Add(dog);
            this.context.SaveChanges();

            return RedirectToAction("ShowAllDogs");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dog = GetDog(id);

            var dogDto = ConvertDogToDto(dog);

            return View(dogDto);
        }

        [HttpPost]
        public IActionResult EditADog(int id, DogDto dogDto)
        {
            var dog = GetDog(id);

            dog.Name = dogDto.Name;
            dog.Age = dogDto.Age;
            dog.Breed = GetBreed(dogDto.BreedName);
            dog.Colour = GetColour(dogDto.ColourName);

            this.context.SaveChanges();
            return RedirectToAction("ShowAllDogs");
        }

        public IActionResult Delete(int id)
        {
            var dog = GetDog(id);

            return View(dog);
        }

        [HttpPost]
        public IActionResult DeleteADog(int id)
        {
            var dog = GetDog(id);

            this.context.Remove(dog);
            this.context.SaveChanges();

            return RedirectToAction("ShowAllDogs");
        }

        private IEnumerable<Dog> GetAllDogies()
        {
            List<Dog> dogs = new List<Dog>(this.context.Dogs
                .Include(x => x.Breed)
                .Include(x => x.Colour));

            return dogs.AsEnumerable();
        }

        private Breed GetBreed(string breedName)
        {
            return context.Breeds
                .FirstOrDefault(x => x.Name == breedName)
                ?? throw new ArgumentException("Breed doesn't exist.");
        }

        private Colour GetColour(string colourName)
        {
            return context.Colours
                .FirstOrDefault(x => x.Name == colourName)
                ?? throw new ArgumentException("Colour doesn't exist."); 
        }

        private DogDto ConvertDogToDto(Dog dog)
        {
            DogDto dogDto = new DogDto();

            dogDto.Id = dog.Id;
            dogDto.Name = dog.Name;
            dogDto.Age = dog.Age;
            dogDto.BreedName = dog.Breed.Name;
            dogDto.ColourName = dog.Colour.Name;

            return dogDto;
        }

        private Dog GetDog(int id)
        {
            return this.context.Dogs
                .Include(x => x.Breed)
                .Include(x => x.Colour)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}