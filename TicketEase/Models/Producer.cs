using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketEase.Data.Base;

namespace TicketEase.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom complet doit etre obligatoirement sa longeure entre 3 et 50")]
        public string FullName { get; set; }
        [Display(Name = "Biographie")]
        [Required(ErrorMessage = "Biographie is required")]
        public string Biographie { get; set; }

        // Les relations
        public List<Movie>? Movies { get; set;}
    }
}
