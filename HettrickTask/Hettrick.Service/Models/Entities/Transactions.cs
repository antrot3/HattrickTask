using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hattrick.Service.Models.Entities
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public double Value { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

    }
}
