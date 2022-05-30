using AutoMapper;
using BL;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub_Jerusalem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayRoomBookingController : ControllerBase
    {
        IDayRoomBookingBL dbl;
        public DayRoomBookingController(IDayRoomBookingBL dbl)
        {
            this.dbl = dbl;
        }
        [HttpGet("{id}")]
        public async Task<DayRoomBooking> GetAsync(int id)
        {
            return await this.dbl.get(id);
        }
        [HttpPost]
        public async Task PostAsync(DayRoomBooking day)
        {
            await this.dbl.post(day);
        }
    }
}
