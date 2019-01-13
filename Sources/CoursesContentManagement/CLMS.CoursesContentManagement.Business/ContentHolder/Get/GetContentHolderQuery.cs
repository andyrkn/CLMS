using System;
using CLMS.Kernel;
using CSharpFunctionalExtensions;

namespace CLMS.CoursesContentManagement.Business
{
    public class GetContentHolderQuery : IQuery<Result<ContentHolderDetailsModel>>
    {
        public Guid ContentHolderId { get; }

        public GetContentHolderQuery(Guid contentHolderId)
        {
            ContentHolderId = contentHolderId;
        }
    }
}