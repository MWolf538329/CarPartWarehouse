namespace CarPartWarehouseAPI.Services
{
    public static class CategoryService
    {
        public static void SetupCategory(this WebApplication app)
        {
            app.MapGet("/categories", (string location) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index => {
                    var degrees = location.Length + index;
                    return $"Temp: {degrees}°C";
                });
                return forecast.ToArray();
            })
            .WithName("GetCategories")
            .WithOpenApi();
        }
    }
}
