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
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biographie")]
        public string Biographie { get; set; }

        // Les relations
        public List<Movie> Movies { get; set;}
    }
}
