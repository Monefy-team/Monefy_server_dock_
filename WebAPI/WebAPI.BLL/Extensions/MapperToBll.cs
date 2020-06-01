using System.Collections.Generic;
using AutoMapper; 
using WebAPI.BLL.DTO;
using WebAPI.DAL.Entities;

namespace WebAPI.BLL.Extensions
{
    public static class MapperToBll
    {
        private static Mapper Mapper { get; set; }

        private static MapperConfiguration Configuration { get; set; }

        static MapperToBll()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Finance, FinanceDto>();
                cfg.CreateMap<User, CreateUserDto>();
                cfg.CreateMap<User, UserDto>();
            });
            
            Mapper = new Mapper(Configuration);
        }

        public static FinanceDto ToBll(this Finance dal)
        {
            return Mapper.Map<Finance, FinanceDto>(dal);
        }

        public static CreateUserDto ToBllCreateUser(this User dal)
        {
            return Mapper.Map<User, CreateUserDto>(dal);
        }
        
        public static UserDto ToBllUserDetail(this User dal)
        {
            return Mapper.Map<User, UserDto>(dal);
        }
        
        public static List<UserDto>ToBllUsersDetail(this List<User> users)
        {
            return Mapper.Map<List<User>, List<UserDto>>(users);
        }
        
        public static List<FinanceDto>ToBllFinances(this List<Finance> finances)
        {
            return Mapper.Map<List<Finance>, List<FinanceDto>>(finances);
        }
    }
}