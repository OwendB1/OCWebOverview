using System.Collections.Immutable;
using OCWebOverview.Data.Database;
using OCWebOverview.Data.Entities;

namespace OCWebOverview.Data.Collections
{
    public class WerknemerCollection(ApplicationDbContext dbContext)
    {
        public event EventHandler? DataChanged;
        protected virtual void DataHasChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<Werknemer> GetAllWerknemers()
        {
            return dbContext.Werknemers.ToImmutableList();
        }

        public bool AddWerknemer(Werknemer w)
        {
            dbContext.Werknemers.Add(w);
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }

        public bool EditWerknemer(Werknemer w)
        {
            var entry = dbContext.Werknemers.FirstOrDefault(werknemer => werknemer.Id == w.Id);
            if (entry is null) return false;
            entry.ColorHexCode = w.ColorHexCode;
            entry.IsActiveInOverview = w.IsActiveInOverview;
            entry.Naam = w.Naam;
            entry.UrenPerWeek = w.UrenPerWeek;
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveWerknemer(Guid id)
        {
            var entry = dbContext.Werknemers.FirstOrDefault(werknemer => werknemer.Id == id);
            if (entry is null) return false;
            dbContext.Werknemers.Remove(entry);
            DataHasChanged();
            return dbContext.SaveChanges() > 0;
        }
    }
}
