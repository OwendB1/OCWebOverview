using OCWebOverview.Data.Database;
using OCWebOverview.Data.Entities;
using System.Collections.Immutable;

namespace OCWebOverview.Data.Collections
{
    public class GemeenteCollection(ApplicationDbContext dbContext)
    {
        public event EventHandler? DataChanged;
        protected virtual void DataHasChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<Gemeente> GetAllGemeentes()
        {
            return dbContext.Gemeentes.ToImmutableList();
        }

        public bool AddGemeente(Gemeente g)
        {
            dbContext.Gemeentes.Add(g);
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }

        public bool EditGemeente(Gemeente g)
        {
            var entry = dbContext.Gemeentes.FirstOrDefault(gemeente => gemeente.Id == g.Id);
            if (entry is null) return false;
            entry.KantoorLocatie = g.KantoorLocatie;
            entry.Naam = g.Naam;
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveGemeente(Guid id)
        {
            var entry = dbContext.Gemeentes.FirstOrDefault(gemeente => gemeente.Id == id);
            if (entry is null) return false;
            dbContext.Gemeentes.Remove(entry);
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }
    }
}
