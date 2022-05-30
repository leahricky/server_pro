using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class MarriageStatus
    {
        public MarriageStatus()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string MarriageStatus1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
