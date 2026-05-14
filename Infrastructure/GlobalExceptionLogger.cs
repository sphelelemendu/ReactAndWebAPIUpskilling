using System.Web.Http.ExceptionHandling;

namespace WebAPI.Infrastructure
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            // Logging will be wired up in issue 10
        }
    }
}
