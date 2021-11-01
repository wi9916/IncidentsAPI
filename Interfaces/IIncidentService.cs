using IncidentsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Interfaces
{
    public interface IIncidentService
    {
        Incident Get(Incident item);

        void Add<T>(T item) where T : class;

        bool AddIncident(Incident item);

        bool AddAccount(Account item);

        bool AddContact(Contact item);

        void Edit<T>(T item) where T : class;

        void Delete<T>(T item, string kay) where T : class;

        void Save();        
    }
}
