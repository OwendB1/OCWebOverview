using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OCWebOverview.Data.Entities
{
    [Owned]
    public class Adres
    {
        public string Straat { get; set; }

        public string HuisNummer { get; set; }

        [RegularExpression("^[1-9][0-9]{3} ?(?!sa|sd|ss|SA|SD|SS)[A-Za-z]{2}$", ErrorMessage = "Postcode is niet geldid, gebruik patroon 1111XX")]
        public string Postcode { get; set; }

        public string Plaats { get; set; }

        public Adres(string straat, string huisNummer, string postcode, string plaats)
        {
            Straat = straat;
            HuisNummer = huisNummer;
            Postcode = postcode;
            Plaats = plaats;
        }

        public Adres()
        {
        }
    }
}
