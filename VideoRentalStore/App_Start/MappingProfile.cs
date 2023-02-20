using AutoMapper;
using VideoRentalStore.Models;
using VideoRentalStore.Models.Dtos;

namespace VideoRentalStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            // Dto to Model
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Id, act => act.Ignore());
        }
    }
}