using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    [Table("article")]
    public class Article
    {
        [Key]
        public int ArticleId { set; get; }

        [StringLength(100)]
        public string Title { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; }

    }
}
