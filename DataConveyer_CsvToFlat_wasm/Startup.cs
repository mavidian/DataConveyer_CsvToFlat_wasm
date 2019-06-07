using Blazor.FileReader;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DataConveyer_CsvToFlat_wasm
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddFileReaderService();
      }

      public void Configure(IComponentsApplicationBuilder app)
      {
         app.AddComponent<App>("app");
      }
   }
}
