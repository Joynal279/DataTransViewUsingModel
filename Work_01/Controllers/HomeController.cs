using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Work_01.Models;

namespace Work_01.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Product()
    {
        string[] pList = { "Iphohne", "Samsung", "Vivo" };
        ViewBag.p = pList;
        return View();
    }

    public ActionResult FileInformation()
    {
        string dr = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(@"/Users/joynalabedin/Documents/");
        int i = 1;
        List<FileInformation> finList = new List<FileInformation>();

        foreach (var f in files)
        {
            FileInformation fin = new FileInformation();
            fin.Id = i;
            fin.Name = Path.GetFileNameWithoutExtension(f);
            fin.Extension = Path.GetExtension(f);
            fin.Path = f;
            fin.Size = new FileInfo(f).Length;

            finList.Add(fin);

            i++;
        }

        ViewBag.res = finList;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

