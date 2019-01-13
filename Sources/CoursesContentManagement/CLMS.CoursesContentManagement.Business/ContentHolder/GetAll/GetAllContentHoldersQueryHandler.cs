using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CLMS.CoursesContentManagement.Domain;
using EnsureThat;
using MediatR;

namespace CLMS.CoursesContentManagement.Business.ContentHolder.GetAll
{
    public class GetAllContentHoldersQueryHandler : RequestHandler<GetAllContentHoldersQuery, IReadOnlyCollection<ContentHolderModel>>
    {
        private readonly IContentHolderRepository contentHolderRepository;
        private readonly IMapper mapper;

        public GetAllContentHoldersQueryHandler(IContentHolderRepository contentHolderRepository, IMapper mapper)
        {
            EnsureArg.IsNotNull(mapper);
            EnsureArg.IsNotNull(contentHolderRepository);
            this.contentHolderRepository = contentHolderRepository;
            this.mapper = mapper;
        }
        protected override IReadOnlyCollection<ContentHolderModel> Handle(GetAllContentHoldersQuery request)
        {
            EnsureArg.IsNotNull(request);

            var contentHolders = contentHolderRepository.GetAll();
            var mappedContentHolder = mapper.Map<IReadOnlyCollection<ContentHolderModel>>(contentHolders);
            return mappedContentHolder;
        }
    }
}