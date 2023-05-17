using KidstellarCase.Application.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace KidstellarCase.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork worker;

        public HomeController(IUnitOfWork worker)
        {
            this.worker = worker;
        }
        public async Task<IActionResult> Index()
        {
            var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
            var result = await worker.UserReadRepo.GetByIdAsync(userId);
            return View($"{result.FirstName} {result.LastName}");
        }
        public IActionResult GetUsers()
        {
            var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
            var result = worker.ParentReadRepo.GetUsersWithParentsByParentId(userId).ToList();
            return View(result);
        }
    }
}
