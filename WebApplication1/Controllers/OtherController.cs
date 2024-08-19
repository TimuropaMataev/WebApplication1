using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class OtherController : Controller
{
    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Update() => View();

    [HttpGet]
    public IActionResult Delete() => View();
}