using System;
using System.Collections.Generic;
using System.Linq;
using CLMS.Kernel.Domain;
using CSharpFunctionalExtensions;

namespace CLMS.CoursesContentManagement.Domain
{
    public class ContentHolder : Entity
    {
        private ContentHolder()
        {
        }

        public Guid OriginId { get; private set; }

        public string Name { get; private set; }

        public string HolderEmail { get; private set; }

        private ICollection<Content> contents = new List<Content>();

        public IEnumerable<Content> Contents
        {
            get => contents.ToList();
            private set => contents = value.ToList();
        }

        public static ContentHolder Create(string name, string holderEmail, Guid originId)
        {
            return new ContentHolder
            {
                Name = name,
                HolderEmail = holderEmail,
                OriginId = originId
            };
        }

        public Result AddContent(string holderEmail, Content content)
        {
            if (HolderEmail == holderEmail)
            {
                contents.Add(content);
                return Result.Ok(); 
            }

            return Result.Fail("Holder email is invalid");
        }
    }
}