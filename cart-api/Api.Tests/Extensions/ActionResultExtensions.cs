using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests.Extensions
{
    public static class ActionResultExtensions
    {
        public static T As<T>(this IActionResult result) where T: class{
            if (result == null)
                throw new ArgumentNullException("result");

            var typed = result as OkObjectResult;

                if (result == null)
                throw new ArgumentException("Provided result is not an instance of OkObjectResult");

            var value = typed.Value as T;

            if (value == null)
                throw new ArgumentException($"provided result.Value can not be casted to {typeof(T).Name}");


            return value;
        }
    }
}
