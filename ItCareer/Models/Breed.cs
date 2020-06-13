using MySql.Data.X.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ItCareer.Models
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name{ get; set; }
        
        [AllowNull]
        public ICollection<Dog> Dogs{ get; set; }
    }
}
