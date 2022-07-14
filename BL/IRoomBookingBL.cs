using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRoomBookingBL
    {
        Task<List<FullRoomBookingDTO>> get(string id);
        //getRoomByParanetrs מקבל טווח תאריכים
        Task<List<FullRoomBookingDTO>> get(int type, DateTime start_dateTime, DateTime end_dateTime);//, TimeSpan start_hour, TimeSpan end_hour);
        Task post(List<RoomBooking> room_bookings, string rName);

        Task put(RoomBooking room_booking_dto);
        Task put(List<RoomBooking> room_bookings);
        Task delete(List<int> ids);
    }
}
