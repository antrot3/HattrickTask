using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hettrick.Servic.Models.Entities
{
    public class SportCategory
    {
        [Key]
        public int Id { get; set; }
        public string KategoryName { get; set; }
        public bool Active1 { get; set; }
        public bool Active1x { get; set; }
        public bool Active2x { get; set; }
        public bool Active12 { get; set; }
        public bool Active2 { get; set; }
        public bool ActiveX { get; set; }
        public virtual ICollection<SportGame> SportGame { get; set; }

    }
}
