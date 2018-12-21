using CLMS.Courses.CrossCuttingConcerns;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.Courses.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private readonly IMediator mediator;

        public BaseApiController(IMediator mediator)
        {
            EnsureArg.IsNotNull(mediator);
            this.mediator = mediator;
        }

        protected Result DispatchCommand<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            return mediator.Send(command).Result;
        }

        protected TResult DispatchCommand<TCommand, TResult>(TCommand command)
            where TResult : class
            where TCommand : ICommand<TResult>
        {
            return mediator.Send(command).Result;
        }

        protected TData DispatchQuery<TQuery, TData>(TQuery query)
            where TQuery : IQuery<TData>
        {
            return mediator.Send(query).Result;
        }
    }
}
