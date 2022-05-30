using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL:IUserBL
    {
        IUserDL udl;
        IRoomBookingDL rb_dl;

        public UserBL(IUserDL udl, IRoomBookingDL rb_dl)
        {
            this.udl = udl;
            this.rb_dl = rb_dl;
        }
        public async Task<List<User>> get(DateTime sd, DateTime ed)
        {
            return await udl.get(sd, ed);
            //TimeSpan t = TimeSpan.Zero;
            //List<RoomBooking> rbl = await rb_dl.get(null, sd, ed, t, t);
            //List<User> lu = new List<User>();
            //foreach (var l in rbl)
            //{

            //    lu.Add(await get(l.IdUser));
            //}
            ////List<User> ul = (List<User>)lu.Select(p => p.IdNumber).Distinct(); 
            //return lu; 
        }
        public async Task<User> get(string id)
        {
            return await udl.get(id);
        }
        public async Task<User> get(int id)
        {
            return await udl.get(id);
        }
        public async Task post(User user)
        {
            await udl.post(user);
        }
        public async Task put(User user)
        {
            await udl.put(user);
        }
    }
}
