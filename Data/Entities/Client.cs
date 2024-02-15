using System.ComponentModel.DataAnnotations;

namespace OCWebOverview.Data.Entities
{
    public class Client
    {
        #region properties
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public string Initialen { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public string Achternaam { get; set; }
        
        [Required]
        public DateTime StartDatum {
            get => _startDatum;
            set => _startDatum = value.Kind == DateTimeKind.Utc ? value : value.ToUniversalTime();
        }
        private DateTime _startDatum;
        
        [Required]
        public DateTime EindDatum
        {
            get => _eindDatum;
            set => _eindDatum = value.Kind == DateTimeKind.Utc ? value : value.ToUniversalTime();
        }
        private DateTime _eindDatum;

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        [Range(1, int.MaxValue, ErrorMessage = "Aantal uren moet minstens 1 zijn.")]
        public int ZorgUren { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public Guid HoofdWerknemerId { get; set; }

        public List<Guid> ExtraWerknemerIds { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public ZorgType ZorgType { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public Guid GemeenteId { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public Adres Adres { get; set; }

        public virtual Gemeente Gemeente { get; set; }
        #endregion

        public Client(string initialen, string achternaam, DateTime startDatum, DateTime eindDatum, int zorgUren, Guid hoofdWerknemerId, List<Guid> extraWerknemerIds, ZorgType zorgType, Guid gemeenteId, Adres adres, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Initialen = initialen;
            Achternaam = achternaam;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            ZorgUren = zorgUren;
            HoofdWerknemerId = hoofdWerknemerId;
            ExtraWerknemerIds = extraWerknemerIds;
            ZorgType = zorgType;
            GemeenteId = gemeenteId;
            Adres = adres;
        }

        public Client() { }
    }

    public enum ZorgType
    {
        Jeugd,
        WMO
    }
}
