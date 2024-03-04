using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3.Models
{
    [Table("Person")]
    internal class Person
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }
}
