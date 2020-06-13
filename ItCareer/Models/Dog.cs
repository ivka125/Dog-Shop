using System;
using System.ComponentModel.DataAnnotations;

namespace ItCareer.Models
{
	public class Dog
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(3)]
		public string Name { get; set; }

		[Required]
        public int BreedId { get; set; }

		public Breed Breed { get; set; }
		
		[Required]
		public int ColourId { get; set; }

		public Colour Colour { get; set; }

		[Required]
		[Range(0, Double.MaxValue)]
		public int Age { get; set; }
    }
}