using IncidentsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Interfaces
{
    public interface IDataService
    {
        void Add<T>(T item) where T : class;

        Incident Get(Incident item);

        Account Get(Account item);

        Contact Get(Contact item);

        void Edit<T>(T item) where T : class;

        void Delete<T>(T item, string kay) where T : class;

        void Save();
    }
}
