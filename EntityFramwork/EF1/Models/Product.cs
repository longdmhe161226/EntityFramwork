using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF1.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { set; get; }

        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        [StringLength(50)]
        public string Provider { set; get; }

        public override string? ToString()
        {
            return ProductId +"\t"+Name+ "\t"+Provider;
        }
    }
}
