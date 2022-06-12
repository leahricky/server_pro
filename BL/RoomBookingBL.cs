using DL;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

   public class RoomBookingBL:IRoomBookingBL
    {

        IRoomBookingDL iroomBooking;

        public RoomBookingBL(IRoomBookingDL iroomBooking)
        {
            this.iroomBooking = iroomBooking;           
        }

        public async Task<List<RoomBooking>> get(string id)
        {
            return await iroomBooking.get(id);
        }

        //getRoomByParanetrs מקבל טווח תאריכים
        public async Task<List<RoomBooking>> get(int type, DateTime start_dateTime, DateTime end_dateTime)
        {
            return await iroomBooking.get(type, start_dateTime, end_dateTime);
        }

        public async Task<int> post(RoomBooking room_booking)
        {
            return await iroomBooking.post(room_booking);
        }

        public async Task put(RoomBooking room_booking)
        {
            await iroomBooking.put(room_booking);
        }

        public async Task put(List<RoomBooking> room_bookings)
        {
            await iroomBooking.put(room_bookings);
        }
        
        public async Task delete(string idNumber)
        {
            await iroomBooking.delete(idNumber);
        }

    }
}
