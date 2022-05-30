using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class DayRoomBooking
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int IdRoomBooking { get; set; }
        [JsonIgnore]
        public virtual RoomBooking IdRoomBookingNavigation { get; set; }
    }
}
