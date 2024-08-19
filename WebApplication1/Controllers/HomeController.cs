using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationContext _context;

    public HomeController(ApplicationContext context)
    {
        _context = context;

        if (!_context.Companies.Any())
        {
            Company oko = new Company { Name = "oko" };
            Company dsoft = new Company { Name = "dsoft" };
            Company dno = new Company { Name = "dno" };
            Company kison = new Company { Name = "kison" };

            User u1 = new User { Name = "Tom", Age = 19, Companies = oko };
            User u2 = new User { Name = "Bob", Age = 22, Companies = dsoft };
            User u3 = new User { Name = "Alex", Age = 20, Companies = oko };
            User u4 = new User { Name = "Tony", Age = 18, Companies = dsoft };
            User u5 = new User { Name = "Kan", Age = 25, Companies = oko };
            User u6 = new User { Name = "Tyn", Age = 27, Companies = oko };
            User u7 = new User { Name = "Alice", Age = 34, Companies = dno };
            User u8 = new User { Name = "Li", Age = 37, Companies = kison };
            User u9 = new User { Name = "Den", Age = 28, Companies = dno };
            User u10 = new User { Name = "Hin", Age = 30, Companies = kison };

            _context.Companies.AddRange(oko, dsoft, dno, kison);
            _context.Users.AddRange(u1, u2, u3, u4, u5, u6, u7, u8, u9, u10);
            _context.SaveChanges();
        }
    }

    public async Task<IActionResult> Index(SortState sortState = SortState.NameAsc)
    {
        IQueryable<User> users = _context.Users.Include(o => o.Companies);

        users = sortState switch
        {
            SortState.NameDesc => users.OrderByDescending(o => o.Name),
            SortState.AgeAsc => users.OrderBy(o => o.Age),
            SortState.AgeDesc => users.OrderByDescending(o => o.Age),
            SortState.CompanyAsc => users.OrderBy(o => o.Companies!.Name),
            SortState.CompanyDesc => users.OrderByDescending(o => o.Companies!.Name),
            _ => users.OrderBy(o => o.Name)
        };

        var viewModel = new IndexViewModel
        {
            Users = await users.AsNoTracking().ToListAsync(),
            Sort = new SortViewModel(sortState)
        };

        return View(viewModel);
    }
}