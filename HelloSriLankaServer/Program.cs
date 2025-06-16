using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using ModelContextProtocol.Server;
using System.ComponentModel;

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

[McpServerToolType]
public static class HelloTool
{
    [McpServerTool(Name = "HelloTool"), Description("Say hello to Sri Lanka")]
    public static void SayHello()
    {
        Console.WriteLine("Hello Sri Lanka!");
    }

    [McpServerTool(Name = "ProvinceCount"), Description("How many provinces are in Sri Lanka")]
    public static void ProvinceCount()
    {
        Console.WriteLine("There are 9 provinces in Sri Lanka.");
    }

    [McpServerTool(Name = "CapitalCity"), Description("What is the capital of Sri Lanka?")]
    public static void CapitalCity()
    {
        Console.WriteLine("The administrative capital of Sri Lanka is Sri Jayawardenepura Kotte, and the commercial capital is Colombo.");
    }

    [McpServerTool(Name = "PopulationInfo"), Description("What is the population of Sri Lanka?")]
    public static void PopulationInfo()
    {
        Console.WriteLine("As of 2024, Sri Lanka has a population of approximately 22 million people.");
    }

    [McpServerTool(Name = "MainLanguages"), Description("What are the main languages spoken in Sri Lanka?")]
    public static void MainLanguages()
    {
        Console.WriteLine("The official languages of Sri Lanka are Sinhala and Tamil. English is widely used for official and commercial purposes.");
    }

    [McpServerTool(Name = "CurrencyInfo"), Description("What is the currency of Sri Lanka?")]
    public static void CurrencyInfo()
    {
        Console.WriteLine("The currency of Sri Lanka is the Sri Lankan Rupee (LKR).");
    }

    [McpServerTool(Name = "FamousFor"), Description("What is Sri Lanka famous for?")]
    public static void FamousFor()
    {
        Console.WriteLine("Sri Lanka is known for its tea, spices, beautiful beaches, historical sites, wildlife, and rich cultural heritage.");
    }

    [McpServerTool(Name = "UNESCOHeritageSites"), Description("How many UNESCO World Heritage Sites are there in Sri Lanka?")]
    public static void UNESCOHeritageSites()
    {
        Console.WriteLine("Sri Lanka has 8 UNESCO World Heritage Sites, including Sigiriya, Polonnaruwa, Anuradhapura, and the Central Highlands.");
    }

    [McpServerTool(Name = "MajorReligions"), Description("What are the major religions in Sri Lanka?")]
    public static void MajorReligions()
    {
        Console.WriteLine("The major religions in Sri Lanka are Buddhism, Hinduism, Islam, and Christianity. Buddhism is the largest religion.");
    }

    [McpServerTool(Name = "IndependenceInfo"), Description("When did Sri Lanka gain independence?")]
    public static void IndependenceInfo()
    {
        Console.WriteLine("Sri Lanka gained independence from British rule on February 4, 1948.");
    }
}
