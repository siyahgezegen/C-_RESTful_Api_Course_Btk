using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        // source ve defination ifadelerine göre mapping işlemi gerçekleşecek.
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>();
        }

    }
}
