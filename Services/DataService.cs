using IncidentsAPI.Interfaces;
using IncidentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Services
{
    public class DataService : IDataService
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

        public Incident Get(Incident item)
        {
            var obj = _db.Set<Incident>().Find(item.IncidentName);
            if(obj is not null)
                obj.Accounts = _db.Set<Account>().Where(p=> p.Incedent.IncidentName == item.IncidentName).ToList();

            if(obj.Accounts is not null)
                foreach (var o in obj.Accounts)
                    o.Contacts = _db.Set<Contact>().Where(p => p.Account.Name == o.Name).ToList();

            return obj;
        }
        public Account Get(Account item) 
        {
            var obj = _db.Set<Account>().Find(item.Name);
            if(obj is not null)
                obj.Contacts = _db.Set<Contact>().Where(p => p.Account.Name == item.Name).ToList();

            return obj;
        }
        public Contact Get(Contact item) 
        {
            var obj = _db.Set<Contact>().Find(item.Email);
            return obj;
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

        public void Delete<T>(T item,string kay) where T : class
        {
            var obj = _db.Set<T>().Find(kay);
            if (obj != null)
                _db.Set<T>().Remove(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
