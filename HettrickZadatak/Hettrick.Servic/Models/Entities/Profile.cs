using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hattrick.Servic.Models.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double AccountBallance { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }



    }
}
