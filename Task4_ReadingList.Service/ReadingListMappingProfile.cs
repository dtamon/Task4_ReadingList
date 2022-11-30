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
                .ForMember(d => d.Authors, o => o.MapFrom(s => s.Authors.Select(a => $"{a.FirstName} {a.LastName}")));
        }
    }
}
