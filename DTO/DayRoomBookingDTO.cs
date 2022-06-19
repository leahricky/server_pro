using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DayRoomBookingDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Day { get; set; }
    }
}
