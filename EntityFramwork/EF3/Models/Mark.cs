using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3.Models
{
    internal class Mark
    {
        [Key]
        public int Id { get; set; }
        public int Marked { get; set; }
        [ForeignKey("PersonId")]
        public int PersonID { get; set;}

    }
}
