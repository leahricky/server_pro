using AutoMapper;
using DL;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub_Jerusalem
{
    public class AutoMapping : Profile
    {
        //IRoomDL rdl;
        public AutoMapping()
        {

           // this.rdl = rdl;

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.MarriageStatus, opts => opts
                      .MapFrom(src => src.IdMarriageStatusNavigation.MarriageStatus1))
                .ForMember(dest => dest.WorkingStatus, opts => opts
                    .MapFrom(src => src.IdWorkingStatusNavigation.WorkingStatus1))
                .ReverseMap();

            CreateMap<RoomBooking, RoomBookingDTO>()
            .ForMember(dest => dest.RoomName, opts => opts
                .MapFrom(src => src.IdRoomNavigation.Name))
            .ReverseMap();//אולי הבעיה ברוורס כי זה רשימה צריך להכניס אחד אחד

          /*  CreateMap<RoomBookingDTO, RoomBooking>()
                .AfterMap(async (rbDTO, rb) =>
                {
                    Room r = await rdl.get(rbDTO.RoomName);
                    rb.IdRoom = r.Id;
                });*/
        }
    }
}
