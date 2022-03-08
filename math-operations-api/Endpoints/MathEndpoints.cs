namespace math_operations_api.Endpoints
{
    public static class MathEndpoints
    {
        public static void MapMathEndpoints(this WebApplication app)
        {
            app.MapPost("/api/v1/mmc", ([FromBody] List<long> values, IMathService math) =>
            {
                if ((bool)(values?.Any(value => value <= 0) | values?.Count < 2)) 
                    return Results.BadRequest("É necessário uma lista com pelo menos 2 valores inteiros positivos.");

                var response = math.CalculateMMC(values);

                return Results.Ok(response);
            });

            app.MapPost("/api/v1/mmc-with-description", ([FromBody] List<long> values, IMathService math) =>
            {
                if ((bool)(values?.Any(value => value <= 0) | values?.Count < 2)) 
                    return Results.BadRequest("É necessário uma lista com pelo menos 2 valores inteiros positivos.");

                var response = math.CalculateMMC_WithDescription(values);

                return Results.Ok(response);
            });
        }
    }
}
