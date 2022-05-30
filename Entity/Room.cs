using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Room
    {
        public Room()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int Id { get; set; }
        public int IdRoomType { get; set; }
        public string Name { get; set; }
        public int XStartPoint { get; set; }
        public int YStartPoint { get; set; }
        public int XEndPoint { get; set; }
        public int YEndPoint { get; set; }
        public int? Capacity { get; set; }
        public bool? Active { get; set; }
        [JsonIgnore]

        public virtual RoomType IdRoomTypeNavigation { get; set; }
        [JsonIgnore]

        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
