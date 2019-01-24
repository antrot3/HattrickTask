using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hattrick.Service.Models.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double AccountBalance { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }



    }
}
