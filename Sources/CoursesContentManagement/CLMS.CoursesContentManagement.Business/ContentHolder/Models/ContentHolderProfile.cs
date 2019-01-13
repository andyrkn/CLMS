using AutoMapper;
using CLMS.CoursesContentManagement.Domain;

namespace CLMS.CoursesContentManagement.Business
{
    public class ContentHolderProfile : Profile
    {
        public ContentHolderProfile()
        {
            CreateMap<Content, ContentModel>();
            CreateMap<Domain.File, FileSummaryModel>();

            CreateMap<Domain.ContentHolder, ContentHolderModel>();
            CreateMap<Domain.ContentHolder, ContentHolderDetailsModel>();
        }
    }
}