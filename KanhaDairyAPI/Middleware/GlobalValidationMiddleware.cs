namespace KanhaDairyAPI.Middleware
{
    public class GlobalValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalValidationMiddleware(RequestDelegate next)
        {
                _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                context.Response.StatusCode = 400;

                var errors = ex.Errors
                    .Select(x => new
                    {
                        Field = x.PropertyName,
                        Error = x.ErrorMessage
                    });

                await context.Response.WriteAsJsonAsync(new
                {
                    Status = false,
                    Message = "Validation Failed",
                    Errors = errors
                });
            }
        }

        //public async Task InvokAsync(HttpContext context)
        //{
        //    if (!context.Request.Path.StartsWithSegments("/api"))
        //    {
        //        await _next(context);
        //        return;
        //    }
        //    if (!context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase) &&
        //        !context.Request.Method.Equals("PUT", StringComparison.OrdinalIgnoreCase))
        //    {
        //        await _next(context);
        //        return;
        //    }
        //    if (!context.Request.ContentType?.Contains("application/json") ?? true)
        //    {
        //        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        //        await context.Response.WriteAsync("Content-Type must be application/json");
        //        return;
        //    }
        //    await _next(context);
        //}
    }
}
