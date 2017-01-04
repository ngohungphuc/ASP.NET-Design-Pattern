using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkPattern.Model
{
    public class Country : Entity<int>
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Country Name")]
        public string Name { get; set; }

        public virtual IEnumerable<Person> Persons { get; set; }
    }
}