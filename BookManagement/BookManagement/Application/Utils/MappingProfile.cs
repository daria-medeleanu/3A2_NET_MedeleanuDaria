using Domain.Entities;
using Application.DTOs;
using AutoMapper;

namespace Application.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
