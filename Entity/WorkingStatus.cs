using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class WorkingStatus
    {
        public WorkingStatus()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string WorkingStatus1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
