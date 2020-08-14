using System.Linq;
using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => 
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));


            CreateMap<User,UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl, opt => 
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
              
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo,PhotosForDetailedDto>();
        }
        
    }
}