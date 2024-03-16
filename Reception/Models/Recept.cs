using System.ComponentModel.DataAnnotations;

namespace ReceptionApp.Models
{
    public class Recept
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, ErrorMessage = "Purpose cannot exceed 255 characters")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Reception date is required")]
        public DateTime DateTime { get; set; }

        public bool? Status { get; set; } = false;
    }
}
