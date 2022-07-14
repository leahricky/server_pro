using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class RoomBooking
    {
        public RoomBooking()
        {
           
        }

        public int Id { get; set; }
        public string IdUser { get; set; }
        public int IdRoom { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int TimeDeviation { get; set; }
       // public int Constancy { get; set; }
        public int Day { get; set; }

        public virtual Room IdRoomNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
