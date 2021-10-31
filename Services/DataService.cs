using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Services
{
    public class DataService
    {
        private readonly DataContext _db;

        public DataService(DataContext dataContext)
        {
            _db = dataContext;
        }

        public void Add<T>(T item) where T : class
        {
            _db.Set<T>().Add(item);
        }

        public List<T> Get<T>(T item) where T : class
        {
            var objs = new List<T>();
            foreach (var obj in _db.Set<T>())
                objs.Add(Get(obj,true));

            return objs;
        }

        public T Get<T>(T item, bool kay) where T : class
        {
            return _db.Set<T>().Find(item);
        }

        public void Edit<T>(T item) where T : class
        {
            var odj = _db.Set<T>().Find(item);
            if (item == null)
            {
                return;
            }

            _db.Entry(item).CurrentValues.SetValues(odj);
            Save();
        }

        public void Delete<T>(T item) where T : class
        {
            var obj = _db.Set<T>().Find(item);
            if (obj != null)
                _db.Set<T>().Remove(item);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
