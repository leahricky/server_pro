using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL : IUserDL
    {
        Hub_JerusalemContext data;
        IRoomBookingDL rb_dl; 
         public  UserDL(Hub_JerusalemContext data, IRoomBookingDL rb_dl)
        { 
            this.data = data;
            this.rb_dl = rb_dl;
        }
        //מה זה?
        public async Task<List<User>> get(DateTime sd, DateTime ed)
        {
            //TimeSpan t = TimeSpan.Zero;
            List<RoomBooking> rbl = await rb_dl.get(0, sd, ed);
            List<User> lu = new List<User>();
            User u;
            foreach (var l in rbl)
            {
              
               lu.Add(await get(l.IdUser));
               
            }
            return lu.Distinct().ToList();
        }


        //האם סינון עיקרי פה והשאר בקליאנט-(מהיר יותר) או שהכל יסונן פה?
        //public async Task<List<User>> get(string id, string firstName, string lastName, string phone, string mail,
        //    string familyStatus, string workinkStatus, bool permanentworker, string occupation, byte[] fingerprint)
        //{
        //   return data.Users.Where(x => (id == null || x.IdNumber == id) &&
        //    (firstName == null || x.FirstName == firstName) &&
        //    (lastName == null || x.LastName == lastName) &&
        //    (phone == null || x.Phone == phone) &&
        //    (mail == null || x.Mail == mail) &&
        //    (familyStatus == null || x.IdMarriageStatusNavigation.MarriageStatus1 == familyStatus) &&
        //    (workinkStatus == null || x.IdWorkingStatusNavigation.WorkingStatus1 == workinkStatus) &&
        //    (permanentworker == null || x.PermanentWorker == permanentworker) &&
        //    (occupation == null || x.Occupation == occupation) &&
        //    (fingerprint == null || x.Fingerprint == fingerprint)).ToList();

        public async Task<User> get(string id)
        {
            return await data.Users.Include(u=>  u.IdMarriageStatusNavigation).Include(u => u.IdWorkingStatusNavigation).SingleOrDefaultAsync(x=>x.IdNumber==id);
        }
        public async Task<User> get(int id)
        {
            return await data.Users.Include(u => u.IdMarriageStatusNavigation).Include(u => u.IdWorkingStatusNavigation).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task post(User user)
        {
            //User u = data.Users.Single(x => x.IdNumber == user.IdNumber);
            /* if (u != null)
                 throw new Exception("user exists!");//לאפשר באנגולר לבחור לעדכן אותו?!
             else
             {*/
            await data.Users.AddAsync(user);
            await data.SaveChangesAsync(); 
          
           // }
        }

        public async Task put(User user)
        {
            User u =  await data.Users.SingleAsync(x => x.IdNumber == user.IdNumber);
            if (u == null)
                throw new Exception("user to change not found:(");
            else
            {
                user.IdNumber = u.IdNumber;
                user.Id = u.Id;

                data.Entry(u).CurrentValues.SetValues(user);
                await data.SaveChangesAsync(); 
            }
        }

    }
}
