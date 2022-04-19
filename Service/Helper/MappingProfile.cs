using AutoMapper;
using Data.EmployeeData.Entities;
using EmployeeManagement.Data.EmployeeData.Entities.StoredProcedure;
using EmployeeManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();

                
            CreateMap<EmployeeListWithPageSort, EmployeeListViewModel>()
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => Utility.DateToString(src.DateOfBirth, "MM/dd/yyyy")));

            CreateMap<Hobby, HobbyViewModel>().ForMember(dest => dest.Hobby, opt => opt.MapFrom(src => src.Hobby1));
            CreateMap<HobbyViewModel, Hobby>().ForMember(dest => dest.Hobby1, opt => opt.MapFrom(src => src.Hobby));

            CreateMap<Skill, SkillViewModel>().ForMember(dest => dest.Skill, opt => opt.MapFrom(src => src.Skill1));
            CreateMap<SkillViewModel, Skill>().ForMember(dest => dest.Skill1, opt => opt.MapFrom(src => src.Skill));

            CreateMap<Role, RoleViewModel>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role1));
            CreateMap<RoleViewModel, Role>().ForMember(dest => dest.Role1, opt => opt.MapFrom(src => src.Role));
        }
    }
}
