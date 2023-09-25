using System;
using System.Collections.Generic;
using AutoMapper;
using TestProject.Data.DbModel.AccountSchema;
using TestProject.Data.DbModel.ConfigurationSchema;
using TestProject.DTO.Account;
using TestProject.DTO.Configuration;
using TestProject.DTO.Configuration.ConfigurationAudit;

namespace TestProject.API.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Configuration
        CreateMap<Configuration, ConfigurationDto>().ReverseMap();
        CreateMap<Configuration, ConfigurationAudit>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ReverseMap();
        CreateMap<ConfigurationAudit, ConfigurationAuditDto>()
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator == null ? "System" : $"{src.Creator.FirstName} {src.Creator.LastName}"))
            .ReverseMap();
        CreateMap<ConfigurationAudit, ExportConfigurationAuditDto>()
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator == null ? "System" : $"{src.Creator.FirstName} {src.Creator.LastName}"))
            .ReverseMap();
        

        #endregion


        CreateMap<UserForRegistrationDto, ApplicationUser>();
        CreateMap<UserForUpdateDto, ApplicationUser>();
        CreateMap<UserForRegistrationDto,UserDto>();
        CreateMap<UserForUpdateDto, UserDto>();

        CreateMap<ApplicationUser, UserDetailsDto>().ReverseMap();
        CreateMap<ApplicationUser, UserDto>().ReverseMap();
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<UserDto, ApplicationUser>();
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<UserDto,  ApplicationUser>().ReverseMap();

        // Role
        // Role
       
    // Organization unit


    


        // var config = new MapperConfiguration(cfg => {
        //     cfg.CreateMap<FacilityEquipmentCreateDto, FacilityEquipmentDto>();
        //     cfg.CreateMap<EquipmentContractCreateDto, EquipmentContractCreateDto>();
        // });
        // config.AssertConfigurationIsValid();
        // config.CreateMapper();




        //.ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator == null ?
        //    "System" : $"{src.Creator.FirstName} " + $"{src.Creator.LastName}"))
        //.ReverseMap();

        

    }
}
