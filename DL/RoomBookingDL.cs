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
    public class RoomBookingDL : IRoomBookingDL
    {

        Hub_JerusalemContext data;
        IRoomDL rd;

        public RoomBookingDL(Hub_JerusalemContext data, IRoomDL rd)
        {
            this.data = data;
            this.rd = rd;
        }

        public async Task<List<FullRoomBookingDTO>> get(string id)
        {
            var toGroup = await data.RoomBookings.Include(rb => rb.IdRoomNavigation)
                .Where(x => x.IdUser == id && x.EndDateTime >= DateTime.Today)
                //.Include(u=>u.IdUserNavigation)
                .ToListAsync();

            return group(toGroup);
        }

        //פונקציה למציאת הזמנה חופפת עבור סינכרון- לשימוש בשרת בלבד.
        private async Task<RoomBooking> getByRoomName(string rName, DateTime start_dateTime, DateTime end_dateTime,int day)
        {
            return await data.RoomBookings
                //.Include(rb => rb.IdRoomNavigation)
                .FirstOrDefaultAsync(rb =>
                (rb.IdRoomNavigation.Name == rName) &&
                (rb.Day == day) &&
               (((rb.StartDateTime <= start_dateTime) && (rb.EndDateTime >= start_dateTime)) ||
              ((rb.EndDateTime >= end_dateTime) && (rb.StartDateTime <= end_dateTime)) ||
              ((rb.StartDateTime >= start_dateTime) && (rb.StartDateTime <= end_dateTime))));
        }

        public async Task<List<FullRoomBookingDTO>> get(int type, DateTime start_dateTime, DateTime end_dateTime)//, TimeSpan start_hour, TimeSpan end_hour)
        {
            var toGroup = await data.RoomBookings.Include(rb => rb.IdRoomNavigation).Where(x =>
              ((start_dateTime == DateTime.Now.Date) && (x.EndDateTime >= end_dateTime)) ||  //  תנאי בשביל קבלת כל ההזמנות הרלוונטיות
              (((x.StartDateTime <= start_dateTime) && (x.EndDateTime >= start_dateTime)) ||
              ((x.EndDateTime >= end_dateTime) && (x.StartDateTime <= end_dateTime)) ||
              ((x.StartDateTime >= start_dateTime) && (x.StartDateTime <= end_dateTime)))
              && ((type == 0) || (x.IdRoomNavigation.IdRoomType == type))).ToListAsync();

            return group(toGroup);
        }

        public List<FullRoomBookingDTO> group(List<RoomBooking> toGroup)
        {
            var roomsGroup = toGroup.GroupBy(rb => rb.IdRoomNavigation.Name);

            List<FullRoomBookingDTO> roomBookings = new List<FullRoomBookingDTO>();

            foreach (var room in roomsGroup)
            {
                var dates = room.GroupBy(r => new {
                    sd = r.StartDateTime.Date,
                    ed = r.EndDateTime.Date,
                    user = r.IdUser
                });
                var days = dates.Select(date => new FullRoomBookingDTO
                {
                    RoomName = room.Key,
                    StartDate = date.Key.sd,
                    EndDate = date.Key.ed,
                    IdUser = date.Key.user,
                    Days = date.Select(day => new DayRoomBookingDTO
                    {
                        Day = day.Day,
                        StartTime = day.StartDateTime,
                        EndTime = day.EndDateTime
                    }).ToList()

                });
                roomBookings.AddRange(days);
            }
            return roomBookings;
        }


        public async Task post(List<RoomBooking> room_bookings,string rName)
        {
            RoomBooking tempRb;
            foreach (RoomBooking rb in room_bookings)
            {
                tempRb = await getByRoomName(rName, rb.StartDateTime, rb.EndDateTime, rb.Day);
                if (tempRb != null)
                    throw new Exception("asynchronization problem :(");
            }

            Room r = await rd.get(rName);

            foreach (RoomBooking rb in room_bookings)
            {
                rb.IdRoom = r.Id;
                //rb.IdRoomNavigation = r;
                await data.RoomBookings.AddAsync(rb);
                await data.SaveChangesAsync();
            }

            //return 1;
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

            RoomBooking tempRb = await getByRoomName(room_booking.IdRoomNavigation.Name, room_booking.StartDateTime, room_booking.EndDateTime,room_booking.Day);
            if (tempRb != null)
                throw new Exception("asynchronization problem :(");

            RoomBooking rb = data.RoomBookings.Single(x => x.Id == room_booking.Id);
            data.Entry(rb).CurrentValues.SetValues(room_booking);
            await data.SaveChangesAsync();
        }

        public async Task put(List<RoomBooking> room_bookings)
        {
            foreach (RoomBooking roomb in room_bookings)
            {
                await put(roomb);
            }
        }

        public async Task delete(List<int> ids)
        {
            //List<RoomBooking> rbs= new List<RoomBooking>();
            //foreach(int id in ids)
            //{
            //    rbs.Add(await data.RoomBookings.FirstOrDefaultAsync(x => x.Id == id));
            //}
              
            //foreach (RoomBooking rb in rbs)
           // {
                // DayRoomBooking drb = await data.DayRoomBookings.SingleOrDefaultAsync(x => x.IdRoomBooking == rb.Id);
                //if(drb!= null) { 
                   // data.DayRoomBookings.Remove(drb);
                    //await data.SaveChangesAsync();
                 //   data.RoomBookings.Remove();
                  //  await data.SaveChangesAsync();
                //}

          //  }
        }
    }
}
