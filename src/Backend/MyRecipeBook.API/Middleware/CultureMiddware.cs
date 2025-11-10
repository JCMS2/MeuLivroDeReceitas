using System.Globalization;

namespace MyRecipeBook.API.Middleware
{
    public class CultureMiddware
    {

        private readonly RequestDelegate _next;
        public CultureMiddware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultireInfo= new CultureInfo(requestedCulture);
            CultureInfo.CurrentCulture = cultireInfo;
            CultureInfo.CurrentUICulture = cultireInfo;

            await _next(context);
        }
    }
}
