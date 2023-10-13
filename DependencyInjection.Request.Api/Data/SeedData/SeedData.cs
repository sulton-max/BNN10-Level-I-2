using DependencyInjection.Request.Api.DataAccess;
using DependencyInjection.Request.Api.Models;

namespace DependencyInjection.Request.Api.Data.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeSeedDataAsync(this AppFileContext context)
    {
        if (!context.Documents.Any())
            await context.Documents.AddRangeAsync(new List<InternalDocument>
            {
                new()
                {
                    Title = "2023 Q3 Financial Report",
                },
                new()
                {
                    Title = "Group 03 Performance Report",
                }
            });

        await context.SaveChangesAsync();
    }
}