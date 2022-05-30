using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public interface IUserBL
    {

        Task<List<User>> get(DateTime sd, DateTime ed);
        Task<User> get(string id);
        Task<User> get(int id);

        Task post(User user);
        Task put(User user);
    }
}
