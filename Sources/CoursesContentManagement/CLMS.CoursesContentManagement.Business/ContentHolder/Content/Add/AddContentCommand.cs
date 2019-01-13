﻿using System;
using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.Business
{
    public class AddContentCommand : ICommand
    {
        public AddContentModel Model { get; }
        public Guid ContentHolderId { get; }

        public AddContentCommand(AddContentModel addModel, Guid contentHolderId)
        {
            Model = addModel;
            ContentHolderId = contentHolderId;
        }
    }
}
