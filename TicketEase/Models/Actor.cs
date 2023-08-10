using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketEase.Data.Base;

namespace TicketEase.Models
{
    public class Actor:IEntityBase
    {
        /*
         * Les DataAnnotations :
         * - sont des attributs en C# qui permettent de spécifier des métadonnées directement dans le code source d'une classe, 
         * notamment pour les propriétés d'une classe.
         * - L'attribut [Key] est l'une des DataAnnotations couramment utilisées dans les classes qui définissent des entités pour les bases de données relationnelles, 
         * en particulier lorsque vous utilisez Entity Framework Core.
         * - [Key] est utilisé pour indiquer la propriété qui joue le rôle de clé primaire de l'entité dans la table correspondante.
         */
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profil Picture")]
        [Required(ErrorMessage = "Profil Picture est obligatoire")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Nom Complet est obligatoire")]
        [StringLength(50,MinimumLength = 3,ErrorMessage = "Le nom complet doit etre obligatoirement sa longeure entre 3 et 50")]
        public string FullName { get; set; }

        [Display(Name = "Biographie")]
        [Required(ErrorMessage = "Biographie est obligatoire")]
        public string Biographie { get; set; }


        // Les relations
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}
