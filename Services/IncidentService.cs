using IncidentsAPI.Interfaces;
using IncidentsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IDataService _context;
        public IncidentService(IDataService context)
        {
            _context = context;
        }
        public Incident Get(Incident item)
        {
            return _context.Get(item);
        }
        public void Add<T>(T item) where T : class
        {
            _context.Add(item);
        }

        public bool AddIncident(Incident item)
        {
            item.IncidentName = null;
            var accounts = item.Accounts.ToList();
            for (var i = 0; i < accounts.Count(); i++)
            {
                var account = _context.Get(accounts[i]);
                if (account is not null)
                {
                    accounts[i] = account;
                    _context.Delete(new Account(), accounts[i].Name);
                }
                else
                {
                    return false;
                }
            }

            _context.Save();
            item.Accounts = accounts;
            Add(item);
            return true;
        }

        public bool AddAccount(Account item)
        {
            if (_context.Get(item) is not null || item.Contacts is null)
                return false;

            var contacts = item.Contacts.ToList();
            for (var i = 0; i < contacts.Count(); i++)
            {
                var contact = _context.Get(contacts[i]);
                if (contact is not null)
                {
                    contacts[i] = contact;
                    _context.Delete(new Contact(), contact.Email);
                }
            }

            _context.Save();
            item.Contacts = contacts;
            Add(item);
            return true;
        }

        public bool AddContact(Contact item)
        {
            if (_context.Get(item) is not null)
                return false;

            Add(item);
            return true;
        }

        public void Edit<T>(T item) where T : class
        {
            _context.Edit(item);
        }
        
        public void Delete<T>(T item, string kay) where T : class
        {
            _context.Delete(item, kay);
        }

        public void Save()
        {
            _context.Save();
        }

        public T Get<T>(T item, string kay) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
