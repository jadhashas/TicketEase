using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketEase.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo Cinema")]
        public string Logo { get; set; }
        [Display(Name = "Name Cinema")]
        public string Name { get; set; }
        [Display(Name = "Discription")]
        public string Description { get; set; }


        // Les relations
        public List<Movie> Movies { get; set; }

    }
}
