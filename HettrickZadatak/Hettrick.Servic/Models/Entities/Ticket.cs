using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hettrick.Servic.Models.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public Double Payment { get; set; }
        public bool CurrentlyActive { get; set; }
        public int ProfileId { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

        public virtual ICollection<TicketToGame> TicketToGame { get; set; }
    }
}
