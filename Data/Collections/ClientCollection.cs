using System.Collections.Immutable;
using OCWebOverview.Data.Database;
using OCWebOverview.Data.Entities;

namespace OCWebOverview.Data.Collections
{
    public class ClientCollection(ApplicationDbContext dbContext)
    {
        public event EventHandler DataChanged;
        protected virtual void DataHasChanged()
        {
            DataChanged.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return dbContext.Clients.ToImmutableList();
        }

        public bool AddClient(Client c)
        {
            dbContext.Clients.Add(c);
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }

        public bool EditClient(Client c)
        {
            var entry = dbContext.Clients.FirstOrDefault(client => client.Id == c.Id);
            if (entry is null) return false;
            entry.Voornaam = c.Voornaam;
            entry.Achternaam = c.Achternaam;
            entry.GemeenteId = c.GemeenteId;
            entry.Adres = c.Adres;
            entry.HoofdWerknemerId = c.HoofdWerknemerId;
            entry.ExtraWerknemerId = c.ExtraWerknemerId;
            entry.StartDatum = c.StartDatum;
            entry.EindDatum = c.EindDatum;
            entry.ZorgType = c.ZorgType;
            entry.ZorgUrenHoofd = c.ZorgUrenHoofd;
            entry.ZorgUrenExtra = c.ZorgUrenExtra;
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveClient(Guid id)
        {
            var entry = dbContext.Clients.FirstOrDefault(client => client.Id == id);
            if (entry is null) return false;
            dbContext.Clients.Remove(entry);
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }
    }
}
