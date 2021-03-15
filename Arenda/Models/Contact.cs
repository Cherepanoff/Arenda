using System;
using System.Collections.Generic;

#nullable disable

namespace Arenda.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public string ContactComment { get; set; }
        public int? ContactFk { get; set; }

        public virtual Arendator ContactFkNavigation { get; set; }
    }
}
