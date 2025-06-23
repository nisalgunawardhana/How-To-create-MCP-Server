using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace HelloSriLankaServer
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Logging.AddConsole(options => {
                options.LogToStandardErrorThreshold = LogLevel.Trace;
            });

            builder.Services.AddMcpServer()
                .WithStdioServerTransport()
                .WithToolsFromAssembly();

            Console.WriteLine(builder.Environment.ContentRootPath);
            var app = builder.Build();

            await app.RunAsync();
        }
    }

    [McpServerToolType]
    public static class HelloSriLankaServerTool
    {
        [McpServerTool(Name = "HelloTool"), Description("Say hello to Sri Lanka")]
        public static string SayHello()
        {
            return "Hello Sri Lanka!";
        }
    }
}