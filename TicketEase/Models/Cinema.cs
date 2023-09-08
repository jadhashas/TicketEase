using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketEase.Data.Base;

namespace TicketEase.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo Cinema")]
        [Required(ErrorMessage = "Logo est obligatoire")]
        public string Logo { get; set; }
        [Display(Name = "Name Cinema")]
        [Required(ErrorMessage = "Name Cinema est obligatoire")]
        public string Name { get; set; }
        [Display(Name = "Discription")]
        [Required(ErrorMessage = "Discription est obligatoire")]
        public string Description { get; set; }


        // Les relations
        public List<Movie>? Movies { get; set; }

    }
}
