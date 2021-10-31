using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Models
{
    public class Account
    {
        [Key]
        public string Name { get; set; }
        public Incident Incedent { get; set; }
        [Required]
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
