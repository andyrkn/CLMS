using System;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace CLMS.Kernel
{
    public static class ResultExtensions
    {
        public static IActionResult AsActionResult(this Result result, Func<IActionResult> func)
        {
            return result.IsFailure ? new BadRequestObjectResult(result.Error) : func();
        }

        public static IActionResult AsActionResult<T>(this Result<T> result, Func<T, IActionResult> func)
        {
            return result.IsFailure ? new BadRequestObjectResult(result.Error) : func(result.Value);
        }
    }
}