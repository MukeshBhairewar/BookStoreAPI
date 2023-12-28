using APIDemoProject.Data;
using APIDemoProject.Models;
using AutoMapper;

namespace APIDemoProject.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
