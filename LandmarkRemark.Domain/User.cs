using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandmarkRemark.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6), MaxLength(12)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }        
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Location> Location { get; set; } = new List<Location>();
    }
}
