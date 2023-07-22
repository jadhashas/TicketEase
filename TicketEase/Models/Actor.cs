using System.ComponentModel.DataAnnotations;

namespace TicketEase.Models
{
    public class Actor
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
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Biographie { get; set; }

        // Les relations
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
