using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IDayRoomBookingDL
    {
        Task post(DayRoomBooking day);
        Task<DayRoomBooking> get(int id);

    }
}
