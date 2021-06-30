using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // ForMember se encarga de darle el URL de la foto principal al usuario que sea la main
            CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl, opts => opts.MapFrom(src => 
            src.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(dest => dest.Age, opts => opts.MapFrom(src =>
            src.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotoDto>();
        }
    }
}