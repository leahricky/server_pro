using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IRoomDL
    {
        Task<List<Room>> get();
        Task<Room> get(string name);
        Task<List<Room>> get2(string room_type);
        Task put(Room room);
        Task post(Room room);

    }
}
