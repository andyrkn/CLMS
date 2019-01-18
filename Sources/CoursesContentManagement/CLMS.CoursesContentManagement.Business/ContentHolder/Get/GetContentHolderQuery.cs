using System;
using CLMS.Kernel;
using CSharpFunctionalExtensions;

namespace CLMS.CoursesContentManagement.Business
{
    public class GetContentHolderQuery : IQuery<Result<ContentHolderDetailsModel>>
    {
        public Guid ContentHolderOriginId { get; }

        public GetContentHolderQuery(Guid contentHolderOriginId)
        {
            ContentHolderOriginId = contentHolderOriginId;
        }
    }
}