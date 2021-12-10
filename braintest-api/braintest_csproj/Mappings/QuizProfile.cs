using AutoMapper;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Mappings
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            // map van een quiz voor het lezen / schrijven in / uit de databank
            CreateMap<Quiz, QuizReadDTO>();
            CreateMap<QuizWriteDTO, Quiz>();
            
        }
    }
}