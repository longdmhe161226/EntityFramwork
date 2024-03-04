using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    public class Tag
    {
        [Key]
        [StringLength(20)]
        public string TagId { set; get; }
        [Column(TypeName = "ntext")]
        public string Content { set; get; }
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
