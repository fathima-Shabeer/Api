# Practice API - Steps

1. Visual Studio > Create new project > ASP.NET Core Web API
   - Name: PracticeApi, Framework: .NET 10, Authentication: None
   - Use controllers: checked, Enable OpenAPI: checked
2. Install Swagger UI: Tools > NuGet Package Manager > Package Manager Console:
      Install-Package Swashbuckle.AspNetCore
3. Delete the template's WeatherForecast.cs and Controllers/WeatherForecastController.cs
4. Copy these files into your project (replace Program.cs):
   - Models/Product.cs
   - Controllers/ProductsController.cs
   - Program.cs
5. Press F5, open /swagger, and try GET, POST, PUT, DELETE.

Learn in this order:
  GET all -> GET by id -> POST -> PUT -> DELETE -> then add EF Core + SQL.
