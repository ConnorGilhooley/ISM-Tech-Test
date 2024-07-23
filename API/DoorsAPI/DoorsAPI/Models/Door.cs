using System.ComponentModel.DataAnnotations;

namespace DoorsAPI.Models
{
    public class Door
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [RegularExpression("Open|Closed", ErrorMessage = "Invalid Open Status")]
        public string IsOpen { get; set; }

        [Required]
        [RegularExpression("Locked|Unlocked", ErrorMessage = "Invalid Lock Status")]
        public string IsLocked { get; set; }

        [Required]
        [RegularExpression("Inactive|Alarmed", ErrorMessage = "Invalid Alarm Status")]
        public string IsAlarmed { get; set; }
    }
}
