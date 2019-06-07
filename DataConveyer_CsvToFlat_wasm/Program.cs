// Copyright © 2019 Mavidian Technologies Limited Liability Company. All Rights Reserved.

using Microsoft.AspNetCore.Blazor.Hosting;

namespace DataConveyer_CsvToFlat_wasm
{
   public class Program
   {
      public static void Main(string[] args)
      {
         CreateHostBuilder(args).Build().Run();
      }

      public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
          BlazorWebAssemblyHost.CreateDefaultBuilder()
              .UseBlazorStartup<Startup>();
   }
}
