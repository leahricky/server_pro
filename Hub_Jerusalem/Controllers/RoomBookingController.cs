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
    public class RoomBookingController : ControllerBase
    {
        IRoomBookingBL roomb_bl;
        IMapper mapper;
        public RoomBookingController(IRoomBookingBL roomb_bl ,IMapper mapper)
        {
            this.roomb_bl = roomb_bl;
            this.mapper = mapper;
        }

        // GET api/<RoomBookingController>/5
        [HttpGet("{id}")]
        public async Task<List<RoomBookingDTO>> GetAsync(string id)
        {
            List <RoomBooking> list_rb= await roomb_bl.get(id);
            List<RoomBookingDTO> list_rb_DTO = mapper.Map<List<RoomBooking>, List<RoomBookingDTO>>(list_rb);
            return list_rb_DTO;
        }

        //POST api/<RoomBookingController>/5
        [HttpGet("{type}/{start_dateTime}/{end_dateTime}")]
        public async Task<List<RoomBookingDTO>> GetAsync( int type, DateTime start_dateTime, DateTime end_dateTime)//,  TimeSpan start_hour, TimeSpan end_hour)
        {
            List<RoomBooking> list_rb = await roomb_bl.get(type, start_dateTime, end_dateTime);//, start_hour, end_hour);
            List<RoomBookingDTO> list_rb_DTO = mapper.Map<List<RoomBooking>, List<RoomBookingDTO>>(list_rb);
            return list_rb_DTO;
        }

        // POST api/<RoomBookingController>
        [HttpPost]
        public async Task<int> PostAsync([FromBody] RoomBookingDTO room_booking)
        {
            RoomBooking rb = mapper.Map<RoomBookingDTO, RoomBooking>(room_booking);
            return await roomb_bl.post(rb);
        }
    

        // PUT api/<RoomBookingController>/5
        [HttpPut]
        public async Task PutAsync([FromBody] RoomBookingDTO room_booking)
        {

            RoomBooking rb = mapper.Map<RoomBookingDTO, RoomBooking>(room_booking);
            await roomb_bl.put(rb);                          
        }

        // PUT api/<RoomBookingController>/5
        [HttpPut("moove_on")]
        public async Task PutAsync([FromBody] List<RoomBookingDTO> room_bookings)
        {
            List<RoomBooking> rbs = mapper.Map< List<RoomBookingDTO>, List<RoomBooking> >(room_bookings);
            await roomb_bl.put(rbs);
        }

        // DELETE api/<RoomBookingController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await roomb_bl.delete(id);
        }
    }
}
