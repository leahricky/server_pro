using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DayRoomBookingDL:IDayRoomBookingDL
    {
        Hub_JerusalemContext data;

        public DayRoomBookingDL(Hub_JerusalemContext data)
        {
            this.data = data;
        }
        public async Task<DayRoomBooking> get(int id)
        {
            return data.DayRoomBookings.SingleOrDefault(x => x.IdRoomBooking==id);
        }

        public async Task post(DayRoomBooking day)
        {
            await data.DayRoomBookings.AddAsync(day);
            await data.SaveChangesAsync();
        }

    }
}

