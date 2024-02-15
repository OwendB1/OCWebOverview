using System.ComponentModel.DataAnnotations;

namespace OCWebOverview.Data.Entities
{
    public class Werknemer
    {
        #region properties
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public string Initialen { get; set; }
        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public string Achternaam { get; set; }

        [Required]
        public DateTime StartDatum
        {
            get => _startDatum;
            set => _startDatum = value.Kind == DateTimeKind.Utc ? value : value.ToUniversalTime();
        }
        private DateTime _startDatum;

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public string ColorHexCode { get; set; }
        [Required]
        public bool IsActiveInOverview { get; set; }
        #endregion

        public Werknemer(string initialen, string achternaam, DateTime startDatum, string colorHexCode, bool isActiveInOverview, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Initialen = initialen;
            Achternaam = achternaam;
            StartDatum = startDatum;
            ColorHexCode = colorHexCode;
            IsActiveInOverview = isActiveInOverview;
        }

        public Werknemer()
        {
        }
    }
}
