using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Entity { 
    public partial class User
    {
        public User()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public int IdMarriageStatus { get; set; }
        public int IdWorkingStatus { get; set; }
        public bool PermanentWorker { get; set; }
        public string Occupation { get; set; }
        public byte[] Fingerprint { get; set; }

        public virtual MarriageStatus IdMarriageStatusNavigation { get; set; }
        public virtual WorkingStatus IdWorkingStatusNavigation { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
