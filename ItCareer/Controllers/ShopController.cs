using System;
using System.Collections.Generic;
using System.Linq;
using ItCareer.Database;
using ItCareer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItCareer.Controllers
{
	public class ShopController : Controller
	{
		private DogContext context;
		
		public ShopController(DogContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
		{
			return View(GetAllDogies());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateADog(Dog dog)
		{
			this.context.Dogs.Add(dog);
			this.context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var dog = (from d in this.context.Dogs
				where d.Id == id
				select d).FirstOrDefault();

			return View(dog);
		}

		[HttpPost]
		public IActionResult EditADog(int id, Dog dog)
		{
			var dogToModify = (
				from d in this.context.Dogs
				where d.Id == id
				select d).FirstOrDefault();

			foreach (var property in dog.GetType().GetProperties())
			{
				property.SetValue(dogToModify, property.GetValue(dog));
			}

			this.context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var dog = (from d in this.context.Dogs
					   where d.Id == id
					   select d).FirstOrDefault();

			return View(dog);
		}

		[HttpPost]
		public IActionResult DeleteADog(int id) 
		{
			var dog = (from d in this.context.Dogs
				where d.Id == id
				select d).FirstOrDefault();

			this.context.Remove(dog);
			this.context.SaveChanges();

			return RedirectToAction("Index");
		}


		private IEnumerable<Dog> GetAllDogies()
		{
			List<Dog> dogs = new List<Dog>(this.context.Dogs);

			return dogs.AsEnumerable();
		}
	}
}