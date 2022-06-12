using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IRoomBL
    {
         Task<List<Room>> get();
         Task<Room> get(string name);
        Task<List<Room>> get2(int IdRoomType);
        Task post(Room room);
        Task put(Room room);
    }
}
