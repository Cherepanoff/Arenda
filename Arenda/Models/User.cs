using System;
using System.Collections.Generic;

#nullable disable

namespace Arenda.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public int? RoleFk { get; set; }

        public virtual Role RoleFkNavigation { get; set; }
    }
}
