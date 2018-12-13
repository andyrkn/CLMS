using System;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.Users
{
    public static class ResultExtensions
    {
        public static IActionResult AsActionResult(this Result result, Func<IActionResult> func)
        {
            return result.IsFailure ? new BadRequestObjectResult(result.Error) : func();
        }
    }
}