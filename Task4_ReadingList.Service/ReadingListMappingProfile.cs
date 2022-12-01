using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Entities;
using Task4_ReadingList.Service.Dto;

namespace Task4_ReadingList.Service
{
    public class ReadingListMappingProfile : Profile
    {
        public ReadingListMappingProfile() 
        {
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>()
                .ForMember(d => d.AuthorName, o => o.MapFrom(s => $"{s.Author.FirstName} {s.Author.LastName}"));

        }
    }
}
