using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Models
{
    public class Incident
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IncidentName { get; set; }
        public string Description { get; set; }

        [Required]
        public IEnumerable<Account> Accounts { get; set; }
    }
}
