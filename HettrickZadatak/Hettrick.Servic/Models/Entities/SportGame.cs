using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hettrick.Servic.Models.Entities
{
    public class SportGame
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public Double Value1 { get; set; }
        public Double Value2 { get; set; }
        public Double Value1X { get; set; }
        public Double Value2X { get; set; }
        public Double Value12 { get; set; }
        public Double ValueX { get; set; }
        public Boolean TopOffer { get; set; }
        public Boolean TopOfferFactor { get; set; }
        public DateTime GameTime { get; set; }
        [ForeignKey("CategoryId")]
        public virtual SportCategory SportCategory { get; set; }

        public virtual ICollection<TicketToGame> TicketToGame { get; set; }
    }
}
