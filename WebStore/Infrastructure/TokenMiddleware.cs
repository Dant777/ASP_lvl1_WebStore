using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebStore.Infrastructure
{
    public class TokenMiddleware
    {
        private const string correntToken = "qwerty123";
        public RequestDelegate Next { get; }

        public TokenMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["referenceToken"];
            //если токена нет, то ничего не делаем
            if (string.IsNullOrEmpty(token))
            {
                await Next.Invoke(context);
            }

            if (token == correntToken)
            {
                //обработка токена....
                //await context.Response.WriteAsync("Token accepted");
                await Next.Invoke(context);
            }
            else
            {
                await context.Response.WriteAsync("Token is incorrent");
            }
        }
    }
}
