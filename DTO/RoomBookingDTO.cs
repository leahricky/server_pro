using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomBookingDTO
    {
        public int Id { get; set; }
        //שטויותתת
        public string IdUser { get; set; }
        //public int IdRoom { get; set; }
        public string RoomName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int TimeDeviation { get; set; }
        public int Day { get; set; }


    }
}
