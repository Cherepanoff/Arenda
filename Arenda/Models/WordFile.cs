using System;
using System.Collections.Generic;

#nullable disable

namespace Arenda.Models
{
    public partial class WordFile
    {
        public int WordId { get; set; }
        public string WordKda { get; set; }
        public string WordPda { get; set; }
        public string WordDa { get; set; }
        public string WordDda { get; set; }
        public string WordStore { get; set; }
        public string WordAttorney { get; set; }
        public string WordDoc { get; set; }
        public int? WordFk { get; set; }

        public virtual Arendator WordFkNavigation { get; set; }
    }
}
