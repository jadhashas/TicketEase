
using System.ComponentModel.DataAnnotations;
using TicketEase.Data.Enums;

namespace TicketEase.Models
{
    public class NewMovieVM
    {
        [Display(Description = "Movie name")]
        [Required(ErrorMessage = "Name est obligatoire")]
        public string Name { get; set; }
        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Description est obligatoire")]
        public string Description { get; set; }
        [Display(Name = "Prix en $")]
        [Required(ErrorMessage = "Prix est obligatoire")]
        public double Price { get; set; }
        [Display(Name = "Image movie")]
        [Required(ErrorMessage = "Image movie est obligatoire")]
        public string ImageURL { get; set; }
        [Display(Name = "Movie start Date")]
        [Required(ErrorMessage = "Start Date est obligatoire")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie end Date")]
        [Required(ErrorMessage = "End Date est obligatoire")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select category")]
        [Required(ErrorMessage = "category est obligatoire")]
        public MovieCategory MovieCategory { get; set; }

        // Les relations
        [Display(Name = "Select actor or actors")]
        [Required(ErrorMessage = "Movie actors est obligatoire")]
        public List<int> ActorIds { get; set; }
        [Display(Name = "Select cinema")]
        [Required(ErrorMessage = "Cinema est obligatoire")]
        public int CinemaId { get; set; }
        [Display(Name = "Select producer")]
        [Required(ErrorMessage = "producer of the movie est obligatoire")]
        public int ProducerId { get; set; }
    }
}
