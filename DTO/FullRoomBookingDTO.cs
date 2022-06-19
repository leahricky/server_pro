using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class FullRoomBookingDTO 
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomName { get; set; }
        public string IdUser { get; set; }
        public List<DayRoomBookingDTO> Days { get; set; }
    }
}
