using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public  class RoomBL:IRoomBL
    {
        IRoomDL rdl;
        public RoomBL(IRoomDL rdl)
        {
            this.rdl = rdl;
        }

        public async Task<List<Room>> get()
        {
            return await rdl.get();
        }

        public async Task<Room> get(string name)
        {
            return await rdl.get(name);
        }

        public async Task<List<Room>> get2(int IdRoomType)
        {
            return await rdl.get2(IdRoomType);
        }

        public async Task post(Room room)
        {
            await rdl.post(room);
        }

        public async Task put(Room room)
        {
            await rdl.put(room);
        }
    }
}
