using System.ComponentModel.DataAnnotations;

namespace OCWebOverview.Data.Entities
{
    public class Client
    {
        #region properties
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public string Voornaam { get; set; }

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
        public int ZorgUrenHoofd { get; set; }

        public int ZorgUrenExtra { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public Guid HoofdWerknemerId { get; set; }

        public Guid? ExtraWerknemerId { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public ZorgType ZorgType { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public Guid GemeenteId { get; set; }

        [Required(ErrorMessage = "Dit veld is benodigd.")]
        public Adres Adres { get; set; }

        public virtual Gemeente Gemeente { get; set; }
        #endregion

        public Client(string voornaam, string achternaam, DateTime startDatum, DateTime eindDatum, int zorgUrenHoofd, int zorgUrenExtra, Guid hoofdWerknemerId, Guid? extraWerknemerId, ZorgType zorgType, Guid gemeenteId, Adres adres, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Voornaam = voornaam;
            Achternaam = achternaam;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            ZorgUrenHoofd = zorgUrenHoofd;
            ZorgUrenExtra = zorgUrenExtra;
            HoofdWerknemerId = hoofdWerknemerId;
            ExtraWerknemerId = extraWerknemerId;
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
