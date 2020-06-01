using AutoMapper;
using WebAPI.BLL.DTO;
using WebAPI.DAL.Entities;

namespace WebAPI.BLL.Extensions
{
    // Статический класс предназначений для преобразования обьекта
    // с Business Layer(Проводник,Бизнесс логика)  в Data Access Layer(База данных)
    public static class MapperToDal
    {
        private static Mapper Mapper { get; set; }

        private static MapperConfiguration Configuration { get; set; }

        static MapperToDal()
        {
            // Задаем конфигурации с какого обьекта в какой преобразовать
            Configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FinanceDto, Finance>();
                cfg.CreateMap<CreateFinanceDto, Finance>();
                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<UserDto, User>();
            });
            
            Mapper = new Mapper(Configuration);
        }

        public static Finance ToDal(this FinanceDto dto)
        {
            return Mapper.Map<FinanceDto, Finance>(dto);
        }
        
        public static Finance ToDalCreateFinance(this CreateFinanceDto dto)
        {
            return Mapper.Map<CreateFinanceDto, Finance>(dto);
        }
        
        public static User ToDal(this CreateUserDto dto)
        {
            return Mapper.Map<CreateUserDto, User>(dto);
        }
    }
}