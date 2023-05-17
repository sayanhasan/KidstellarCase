using KidstellarCase.Application.Repositories.UnitOfWork;
using KidstellarCase.Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace KidstellarCase.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork worker;
        public UserController(IUnitOfWork worker)
        {
            this.worker = worker;
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await worker.UserReadRepo.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Parent model)
        {
            var result = await worker.UserReadRepo.GetByIdAsync(model.Id);
            result.FirstName = model.FirstName;
            result.LastName = model.LastName;
            worker.UserWriteRepo.Update(result);
           await worker.CommitAsync();
            return Ok();
        }
    }
}
