using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hattrick.Service.Models.Entities
{
    public class TicketToGame
    {
        [Key]
        public int Id { get; set; }
        public int SportGameId { get; set; }
        public int TicketId { get; set; }
        public double PairCoefficient { get; set; }
        public string SelectedValue { get; set; }

        [ForeignKey("SportGameId")]
        public virtual SportGame SportGame { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

    }
}
