using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace pwaWebAPIFx.Middlewares
{
    public class HeaderPostRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderPostRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                IHeaderDictionary headers = context.Request.Headers;
                
                //TODO: msanka : to check response for some logic before return
                
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