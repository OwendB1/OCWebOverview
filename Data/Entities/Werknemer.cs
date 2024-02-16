using System.ComponentModel.DataAnnotations;

namespace OCWebOverview.Data.Entities
{
    public class Werknemer
    {
        #region properties
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Dit veld is benodigd.")]
        [Range(1, int.MaxValue, ErrorMessage = "Aantal uren moet minstens 1 zijn.")]
        public int UrenPerWeek { get; set; }

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

        public Werknemer(string naam, DateTime startDatum, int urenPerWeek, string colorHexCode, bool isActiveInOverview, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Naam = naam;
            UrenPerWeek = urenPerWeek;
            StartDatum = startDatum;
            ColorHexCode = colorHexCode;
            IsActiveInOverview = isActiveInOverview;
        }

        public Werknemer()
        {
        }
    }
}
