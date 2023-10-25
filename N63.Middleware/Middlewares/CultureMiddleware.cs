using System.Globalization;

namespace N63.Middleware.Middlewares;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // culture - locale - millatni code
        // current date format in us - 12/12/2021
        // current date format in russian - 12.12.2021

        // ?pageSize=10&pageToken=1?culture=ru-RU

        // api/test/?culture=ru-RU
        // api/orders/?culture=ru-RU

        var cultureQuery = context.Request.Query["culture"];
        if (!string.IsNullOrWhiteSpace(cultureQuery))
        {
            var culture = new CultureInfo(cultureQuery);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }

        await _next(context);
    }
}