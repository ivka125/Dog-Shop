using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ItCareer.Models
{
    [Table("Owners")]
    public class Owner
    {
        [Key]

        public int Id { get; set; }

        [MinLength(5)]
        
        [DataType(DataType.Text)]
       
        [Required]
        public string Name { get; set; }
        
        [Required]
        
        [Range(0, 150)]

        public int Age { get; set; }
      
        [AllowNull]
        public ICollection<Dog> Dogs { get; set; }

    }
}
