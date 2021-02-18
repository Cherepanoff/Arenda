using System;
using System.Collections.Generic;

#nullable disable

namespace Arenda.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentName { get; set; }
        public int? CommentFk { get; set; }

        public virtual Arendator CommentFkNavigation { get; set; }
    }
}
