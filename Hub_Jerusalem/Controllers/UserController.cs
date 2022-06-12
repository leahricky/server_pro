using AutoMapper;
using BL;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hub_Jerusalem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL ubl;
        IMapper _mapper;
        ILogger<UserController> logger;
        /*        Dictionary<int, string> working= new Dictionary<int, string>();*/
        Dictionary<string, int> wStatus = new Dictionary<string, int>() { { "שכירה" ,18 },{"עצמאית" , 19},{ "פרילנסרית" ,20} };
        Dictionary<string, int> mStatus = new Dictionary<string, int>() { { "נשואה" ,13 }, { "רווקה" ,14} };


        public UserController(IUserBL ubl, IMapper _mapper,ILogger<UserController> logger)
        {
            this.ubl = ubl;
            this._mapper = _mapper;
            this.logger = logger;
        }

        [HttpGet("{sd}/{ed}")]
        public async Task<List<UserDTO>> GetAsync( DateTime sd, DateTime ed)
        {
            List<User> users = await ubl.get(sd,ed);
            List<UserDTO> u = _mapper.Map<List<User>, List<UserDTO>>(users);
            return u;
        }

        // GET api/<UserController>/5
        [HttpGet("id_number/{id_number}")]
        public async Task<UserDTO> GetAsync(string id_number)
        {
            User user = await ubl.get(id_number);
            UserDTO u = _mapper.Map<User, UserDTO>(user);
            return u;
        }
        [HttpGet("id/{id}")]
        public async Task<UserDTO> GetAsync(int id)
        {
            User user = await ubl.get(id);
            UserDTO u = _mapper.Map<User, UserDTO>(user);
            return u;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task PostAsync([FromBody] UserDTO user)
        {
            User u = _mapper.Map<UserDTO, User>(user);
            u.IdMarriageStatus = mStatus[user.MarriageStatus];
            u.IdWorkingStatus = wStatus[user.WorkingStatus];
            await ubl.post(u);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task PutAsync([FromBody] UserDTO user)
        {
            User u = _mapper.Map<UserDTO, User>(user);
            u.IdMarriageStatus = mStatus[user.MarriageStatus];
            u.IdWorkingStatus = wStatus[user.WorkingStatus];
            await ubl.put(u);
        }

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
