using DTO;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RoomBookingDL:IRoomBookingDL
    {

        Hub_JerusalemContext data;
        IRoomDL rd;
        public RoomBookingDL(Hub_JerusalemContext data,IRoomDL rd)//, IUserDL u_dl)
        {
            this.data = data;
            this.rd = rd;
        }

        public async Task<List<RoomBooking>> get(string id)
        {
            return await data.RoomBookings.Include(rb=> rb.IdRoomNavigation)
                .Where(x => x.IdUser == id && x.EndDateTime >= DateTime.Now)
                //.Include(u=>u.IdUserNavigation)
                .ToListAsync();
        }

        //getRoomByParanetrs מקבל טווח תאריכים
        //אפשר לחזור ולקצר את התנאים לכשיזדמןןןןןןןןןן
        public async Task<List<RoomBooking>> get(int type, DateTime start_dateTime, DateTime end_dateTime)//, TimeSpan start_hour, TimeSpan end_hour)
        {
            return await data.RoomBookings.Include(rb => rb.IdRoomNavigation).Where(x =>
            //((start_dateTime == null) && (x.EndDateTime >= end_dateTime)) ||  //תנאי בשביל קבלת כל ההזמנות הרלוונטיות
            (((x.StartDateTime <= start_dateTime) && (x.EndDateTime >= start_dateTime) )||
            ((x.EndDateTime >= end_dateTime) && (x.StartDateTime <= end_dateTime)) ||
            ((x.StartDateTime >= start_dateTime) && (x.StartDateTime <= end_dateTime)))
            &&((type == 0)||(x.IdRoomNavigation.IdRoomType == type))).ToListAsync();

            /*return await data.RoomBookings.Where(x => (x.StartDateTime >= start_dateTime) && (x.EndDateTime <= end_dateTime) &&
            ((x.StartHour == TimeSpan.Zero) && (x.EndHour == TimeSpan.Zero)) || ((x.StartHour >= start_hour) && (x.EndHour <= end_hour)) &&((type==null)||
            (x.IdRoomNavigation.IdRoomTypeNavigation.RoomType1 == type))).ToListAsync();*/
        }

        public async Task<int> post(RoomBooking room_booking)
        {
            //RoomBooking rb = data.RoomBookings.Single(x => x.IdUserNavigation== room_booking.IdUserNavigation);
            //if(rb != null)
            //    throw new Exception("user does not exist");

            //List<RoomBooking> rbs = await data.RoomBookings
            //    .Where(x => x.IdRoom == room_booking.IdRoom &&
            //     x.IdRoomNavigation.Name == room_booking.IdRoomNavigation.Name)
            //    .ToListAsync();
            //foreach (var roomb in rbs)
            //{
            //    if (((room_booking.StartDate >= roomb.StartDate) ||
            //        (room_booking.EndDate <= roomb.EndDate)) &&
            //        ((room_booking.StartHour >= roomb.StartHour) ||
            //        (room_booking.EndHour <= roomb.EndHour)))
            //    {
            //        throw new Exception("asynchronization problem :(");
            //    }
            //}
            

            Room r = await rd.get(room_booking.IdRoomNavigation.Name);
            room_booking.IdRoom = r.Id;
            await data.RoomBookings.AddAsync(room_booking);
            await data.SaveChangesAsync();
         
            return room_booking.Id;
        }

        public async Task put(RoomBooking room_booking)
        {
            //List<RoomBooking> rbs = await data.RoomBookings.Where(x => (x.IdRoom == room_booking.IdRoom) && (x.IdRoomNavigation.Name == room_booking.IdRoomNavigation.Name)).ToListAsync();
            //foreach (var roomb in rbs)
            //{
            //    if (((room_booking.StartDate >= roomb.StartDate) ||
            //        (room_booking.EndDate <= roomb.EndDate)) &&
            //        ((room_booking.StartHour >= roomb.StartHour) ||
            //        (room_booking.EndHour <= roomb.EndHour)))
            //    {
            //        throw new Exception("asynchronization problem :(");
            //    }
            //}
            RoomBooking rb = data.RoomBookings.Single(x => x.Id == room_booking.Id);
            data.Entry(rb).CurrentValues.SetValues(room_booking);
            await data.SaveChangesAsync();  
        }

        public async Task put(List<RoomBooking> room_bookings)
        {
            foreach (var roomb in room_bookings)
            {
                await put(roomb);
            }
        }

        public async Task delete(string idNumber)
        {
            List<RoomBooking> rbs = await data.RoomBookings.Where(x=>x.IdUser==idNumber).ToListAsync();
            foreach (RoomBooking rb in rbs)
            {
                data.RoomBookings.Remove(rb);
                await data.SaveChangesAsync();
            }
        }
    }
}
