using Microsoft.Extensions.DependencyInjection;

namespace CSVConvert;

public static class IServiceCollectionExtensions
{
    public static void AddCsvConverter(this IServiceCollection services)
    {
        services.AddScoped<ICsvConverter, CsvConverter>();
    }
}
