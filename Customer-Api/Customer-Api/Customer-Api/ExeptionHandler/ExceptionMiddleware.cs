using Customer_DataAccess.Exeptions;
using System.Net;

namespace Customer_Api.ExeptionHandler
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {

            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";


            switch (exception)
            {
                case CustomerNotFindExeption:
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = exception.Message
                    }.ToString());
                    break;


                default:
                    break;
            }

        }

    }


}
