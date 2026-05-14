using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace WebAPI.Infrastructure
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ResponseMessageResult(
                context.Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new { message = "An unexpected error occurred. Please try again later." }
                )
            );
        }
    }
}
