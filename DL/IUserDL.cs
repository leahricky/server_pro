using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {

        //Task<list<User> get(string id,string firstName,string lastName,string phone,string mail,
        //    string familyStatus, string workinkStatus,bool permanentworker, string occupation, byte[] fingerprint);
        Task<List<User>> get(DateTime sd, DateTime ed);
        Task<User> get(string id);
        Task<User> get(int id);

        Task post(User user);
        Task put(User user);

    }
}
