using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Models
{
    public class Contact
    {
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Account Account { get; set; }
    }
}
