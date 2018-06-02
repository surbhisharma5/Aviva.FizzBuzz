namespace Aviva.FizzBuzz.Models
{
    using Interface;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class FizzBuzzModel
    {
        [Required]
        [Display(Name = "Please enter the number")]
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int? Number { get; set; }

        public List<IFizzBuzz> FizzBuzzList { get; set; }
    }
}
    
