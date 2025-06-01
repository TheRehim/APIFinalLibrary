using APIFinalLibrary.Utilities.Formatter;

namespace APIFinalLibrary.Extensions
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config =>
            {
                config.OutputFormatters.Add(new CsvOutputFormatter());
            });
    }
}
