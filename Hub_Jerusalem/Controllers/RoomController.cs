using AutoMapper;
using BL;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hub_Jerusalem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRoomBL rbl;
        IMapper _mapper;
        public RoomController(IRoomBL rbl, IMapper _mapper)
        {
            this.rbl = rbl;
            this._mapper = _mapper;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public async Task<List<Room>> GetAsync()
        {
            return await rbl.get();
        }

        // GET api/<RoomController>/"a"
        [HttpGet("name/{name}")]
        public async Task<Room> GetAsync(string name)
        {
            return await rbl.get(name);
        }

        // GET api/<RoomController>/5
        [HttpGet("IdRoomType/{IdRoomType}")]
        public async Task<List<Room>> Get2Async(int IdRoomType)
        {
            return await rbl.get2(IdRoomType);
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task PostAsync([FromBody] Room room)
        {
            await rbl.post(room);
        }

        // PUT api/<RoomController>/5
        [HttpPut]
        public async Task PutAsync([FromBody] Room room)
        {
            await rbl.put(room);
        }

        // DELETE api/<RoomController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
        //}
    }
}
