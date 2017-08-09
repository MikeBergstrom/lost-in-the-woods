using System.ComponentModel.DataAnnotations;
 
namespace lost.Models
{
    public class Hike : BaseEntity
    {
        // Class definition
        public int id {get; set;}
        [Required(ErrorMessage="Trail name is required")]
        public string name {get; set;}
        [MinLength(10)]
        public string description {get; set;}
        [RegularExpression("([0-9]+)")]
        public double length {get; set;}
        [RegularExpression("([0-9]+)")]
        public int elevation {get; set;}
        [RegularExpression(@"^[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+))?$", ErrorMessage="Longitude not in proper format")]
        public double longitude {get; set;}
        [RegularExpression(@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+))?$", ErrorMessage="Latitude not in proper format")]
        public double latitude {get; set;}
    }
}