using AutoMapper;
using DataAccess.Entity;
using Models;
using System.Globalization;
using System.Web.WebPages;

namespace New_WrestlingSchool
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConnfig = new MapperConfiguration(config =>
            {
                config.CreateMap<SchoolModel, School>()
                .ForMember(f => f.CreatedAt, mf => mf.MapFrom(d => Convert.ToDateTime(d.CreateDate)));

                config.CreateMap<School, SchoolModel>()
                .ForMember(f => f.CreateDate, mf => mf.MapFrom(d => d.CreatedAt == null ? "تاریخ ثبت نام وجود ندارد" :
                Convert.ToDateTime(d.CreatedAt).ToString("yyyy/MM/dd")));

                config.CreateMap<ClassRoomModel, ClassRoom>()
              .ForMember(f => f.CreatedAt, mf => mf.MapFrom(d => Convert.ToDateTime(d.CreateDate)));


                config.CreateMap<ClassRoom, ClassRoomModel>()
                .ForMember(f => f.CreateDate, mf => mf.MapFrom(d => d.CreatedAt == null ? "تاریخ ثبت نام وجود ندارد" :
                Convert.ToDateTime(d.CreatedAt).ToString("yyyy/MM/dd"/*, new CultureInfo("fa-IR"))*/)))
                .ForMember(d => d.SchoolName, mf => mf.MapFrom(s => s.School.Name));



            });
            return mappingConnfig;
        }
    }
}
