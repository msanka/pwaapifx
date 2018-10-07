using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace pwaWebAPIFx.Middlewares
{
    public class HeaderPreRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderPreRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                IHeaderDictionary headers = context.Request.Headers;

                //TODO: msanka: to check req contains any api_key to enable processing further or reject right away
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await _next.Invoke(context);
            }
        }
    }
}