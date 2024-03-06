using AutoMapper;
using MovieRateApp.DTO;
using MovieRateApp.Models;

namespace MovieRateApp.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
        }
    }
}
