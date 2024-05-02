using AutoMapper;
using BL.BO;
using BL.Models;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Dal;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client,BLReturnClient>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Fhone, opt => opt.MapFrom(src => src.Fhone))
            .ForMember(dest => dest.Years, opt => opt.MapFrom(src =>DateTime.Now.Year-src.BirthDate.Year))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TypeMemberCodeNavigation.Type))
            .ForMember(dest => dest.MonthlyPayment, opt => opt.MapFrom(src => src.TypeMemberCodeNavigation.MonthlyPayment));
        //CreateMap<Client, BLsimpleClient>();
        CreateMap<Coach, BLCoach>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Fhone, opt => opt.MapFrom(src => src.Fhone))
            .ForMember(dest => dest.SalaryForHower, opt => opt.MapFrom(src => src.SalaryForHower))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
        CreateMap<Training,BLTrining>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<TimeTraining, BLschedule>()
              .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Day))
              .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
              .ForMember(dest => dest.NumberRoom, opt => opt.MapFrom(src => src.NumberRoom));
      
    }

}
