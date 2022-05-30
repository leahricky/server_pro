using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DayRoomBookingBL : IDayRoomBookingBL
    {
        IDayRoomBookingDL ddl;
        public DayRoomBookingBL(IDayRoomBookingDL ddl)
        {
            this.ddl = ddl;
        }
        public async Task<DayRoomBooking> get(int id)
        {
            return await this.ddl.get(id);
        }
        public async Task post(DayRoomBooking day)
        {
            await this.ddl.post(day);
        }
    }
}
