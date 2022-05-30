using AutoMapper;
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
        public AutoMapping()
        {
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
        }
    }
}
