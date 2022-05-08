using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleBank.Data;
using SampleBank.Models;


namespace SampleBank.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AdvanceUser> _userManager;
    private readonly SignInManager<AdvanceUser> _signInManager;
    

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<AdvanceUser> userManager, SignInManager<AdvanceUser> signInManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Actions(){
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // private static Chart GenerateBarChart()
    // {
    //     Chart chart = new Chart();
    //     chart.Type = Enums.ChartType.Bar;

    //     Data data = new Data();
    //     data.Labels = new List<string>() { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };

    //     BarDataset dataset = new BarDataset()
    //     {
    //         Label = "# of Votes",
    //         Data = new List<double>() { 12, 19, 3, 5, 2, 3 },
    //         BackgroundColor = new List<ChartColor>
    //         {
    //             ChartColor.FromRgba(255, 99, 132, 0.2),
    //             ChartColor.FromRgba(54, 162, 235, 0.2),
    //             ChartColor.FromRgba(255, 206, 86, 0.2),
    //             ChartColor.FromRgba(75, 192, 192, 0.2),
    //             ChartColor.FromRgba(153, 102, 255, 0.2),
    //             ChartColor.FromRgba(255, 159, 64, 0.2)
    //         },
    //         BorderColor = new List<ChartColor>
    //         {
    //             ChartColor.FromRgb(255, 99, 132),
    //             ChartColor.FromRgb(54, 162, 235),
    //             ChartColor.FromRgb(255, 206, 86),
    //             ChartColor.FromRgb(75, 192, 192),
    //             ChartColor.FromRgb(153, 102, 255),
    //             ChartColor.FromRgb(255, 159, 64)
    //         },
    //         BorderWidth = new List<int>() { 1 }
    //     };

    //     data.Datasets = new List<Dataset>();
    //     data.Datasets.Add(dataset);

    //     chart.Data = data;

    //     var options = new Options
    //     {
    //         Scales = new Scales()
    //     };

    //     var scales = new Scales
    //     {
    //         YAxes = new List<Scale>
    //         {
    //             new CartesianScale
    //             {
    //                 Ticks = new CartesianLinearTick
    //                 {
    //                     BeginAtZero = true
    //                 }
    //             }
    //         },
    //         XAxes = new List<Scale>
    //         {
    //             new BarScale
    //             {
    //                 BarPercentage = 0.5,
    //                 BarThickness = 6,
    //                 MaxBarThickness = 8,
    //                 MinBarLength = 2,
    //                 GridLines = new GridLine()
    //                 {
    //                     OffsetGridLines = true
    //                 }
    //             }
    //         }
    //     };

    //     options.Scales = scales;

    //     chart.Options = options;

    //     chart.Options.Layout = new Layout
    //     {
    //         Padding = new Padding
    //         {
    //             PaddingObject = new PaddingObject
    //             {
    //                 Left = 10,
    //                 Right = 12
    //             }
    //         }
    //     };

    //     return chart;
    // }
}
