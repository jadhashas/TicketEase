using TicketEase.Models;

namespace TicketEase.Data.ViewModels
{
    public class NewMovieDropDownsVM
    {
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
        public NewMovieDropDownsVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }
    }
}
