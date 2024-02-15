using System.ComponentModel.DataAnnotations;

namespace OCWebOverview.Data.Entities
{
    public class Gemeente
    {
        #region properties
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public Adres KantoorLocatie { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        #endregion

        public Gemeente(string naam, Adres kantoorLocatie, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Naam = naam;
            KantoorLocatie = kantoorLocatie;
        }

        public Gemeente()
        {
        }
    }
}
