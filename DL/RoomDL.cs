using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
  public  class RoomDL: IRoomDL
    {
        Hub_JerusalemContext data;

        public RoomDL(Hub_JerusalemContext data)
        {
            this.data = data;
        }

        public async Task<List<Room>> get()
        {
            return await data.Rooms.Where(x => x.Active == true).ToListAsync();
        }

        public async Task<Room> get(string name)
        {
            return await data.Rooms.SingleOrDefaultAsync(x => x.Name== name);
        }

        public async Task<List<Room>> get2(int IdRoomType)
        {
            return await data.Rooms.Where(x => (x.Active==true)&&(x.IdRoomTypeNavigation.Id == IdRoomType)).ToListAsync();
        }

        public async Task put(Room room)
        {
            Room r = await data.Rooms.SingleOrDefaultAsync(x => x.Name == room.Name);
            if (r == null)
                throw new Exception("room to change not found:(");
            else
            {
                data.Entry(r).CurrentValues.SetValues(room);
                await data.SaveChangesAsync();
            }
        }

        public async Task post(Room room)
        {
            await data.Rooms.AddAsync(room);
            await data.SaveChangesAsync();
        }
    }
}
