using KidstellarCase.Application.Helpers;
using KidstellarCase.Application.Repositories.UnitOfWork;
using KidstellarCase.Domain.Entites;
using KidstellarCase.Domain.Enums;
using KidstellarCase.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidstellarCase.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUnitOfWork worker;

        public AuthController(IUnitOfWork worker)
        {
            this.worker = worker;
        }

        [HttpGet]
        public async Task<IActionResult> UserLogin()
        {
            return View("UserLoginView");
        }
        [HttpGet]
        public IActionResult ParentLogin()
        {
            return View("ParentLoginView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            User user = new(); Parent parent = new();
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Username)) return BadRequest(ModelState);
            model.Password = PasswordEncryptor.Encrypt(model.Password);
            if (model.Role == Role.User)
            {
                user = await worker.UserReadRepo.GetSingleAsync(x => x.Username == model.Username && x.Password == model.Password);
                if (parent.Id == Guid.Empty) return Unauthorized();
            }
            else
            {
                parent = await worker.ParentReadRepo.GetSingleAsync(x => x.Username == model.Username && x.Password == model.Password);
                if (parent.Id == Guid.Empty) return Unauthorized();
            }

            HttpContext.Session.SetString("Role", Enum.GetName(model.Role));
            HttpContext.Session.SetString("UserId", model.Role == Role.Parent ? parent.Id.ToString() : user.Id.ToString());
            return model.Role == Role.Parent ? RedirectToAction("GetUsers", "Home") : RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            var role = HttpContext.Session.GetString("Role") == Enum.GetName(Role.User) ? Role.User : Role.Parent;
            HttpContext.Session.Clear();
            return role == Role.User ? RedirectToAction("UserLogin") : RedirectToAction("ParentLogin");
        }
    }
}
