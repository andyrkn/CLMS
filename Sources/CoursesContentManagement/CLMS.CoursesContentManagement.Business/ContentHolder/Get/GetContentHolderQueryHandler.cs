using System.Linq;
using AutoMapper;
using CLMS.CoursesContentManagement.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace CLMS.CoursesContentManagement.Business.ContentHolder.Get
{
    public class GetContentHolderQueryHandler : RequestHandler<GetContentHolderQuery, Result<ContentHolderDetailsModel>>
    {
        private readonly IContentHolderRepository contentHolderRepository;
        private readonly IMapper mapper;

        public GetContentHolderQueryHandler(IContentHolderRepository contentHolderRepository, IMapper mapper)
        {
            EnsureArg.IsNotNull(mapper);
            EnsureArg.IsNotNull(contentHolderRepository);
            this.contentHolderRepository = contentHolderRepository;
            this.mapper = mapper;
        }

        protected override Result<ContentHolderDetailsModel> Handle(GetContentHolderQuery request)
        {
            EnsureArg.IsNotNull(request);

            Maybe<Domain.ContentHolder> contentHolder = contentHolderRepository
                .GetAll()
                .FirstOrDefault(x => x.OriginId == request.ContentHolderOriginId);

            return contentHolder.ToResult("Content holder not found!")
                .Map(x => mapper.Map<ContentHolderDetailsModel>(x));
        }
    }
}