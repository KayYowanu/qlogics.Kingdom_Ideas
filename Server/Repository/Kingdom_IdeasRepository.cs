using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using qlogics.Kingdom_Ideas.Models;

namespace qlogics.Kingdom_Ideas.Repository
{
    public class Kingdom_IdeasRepository : IKingdom_IdeasRepository, IService
    {
        private readonly Kingdom_IdeasContext _db;

        public Kingdom_IdeasRepository(Kingdom_IdeasContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Kingdom_Ideas> GetKingdom_Ideass(int ModuleId)
        {
            return _db.Kingdom_Ideas.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Kingdom_Ideas GetKingdom_Ideas(int Kingdom_IdeasId)
        {
            return _db.Kingdom_Ideas.Find(Kingdom_IdeasId);
        }

        public Models.Kingdom_Ideas AddKingdom_Ideas(Models.Kingdom_Ideas Kingdom_Ideas)
        {
            _db.Kingdom_Ideas.Add(Kingdom_Ideas);
            _db.SaveChanges();
            return Kingdom_Ideas;
        }

        public Models.Kingdom_Ideas UpdateKingdom_Ideas(Models.Kingdom_Ideas Kingdom_Ideas)
        {
            _db.Entry(Kingdom_Ideas).State = EntityState.Modified;
            _db.SaveChanges();
            return Kingdom_Ideas;
        }

        public void DeleteKingdom_Ideas(int Kingdom_IdeasId)
        {
            Models.Kingdom_Ideas Kingdom_Ideas = _db.Kingdom_Ideas.Find(Kingdom_IdeasId);
            _db.Kingdom_Ideas.Remove(Kingdom_Ideas);
            _db.SaveChanges();
        }
    }
}
