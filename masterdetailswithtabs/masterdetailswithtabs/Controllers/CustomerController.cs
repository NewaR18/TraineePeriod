using masterdetailswithtabs.Repository;
using Microsoft.AspNetCore.Mvc;

namespace masterdetailswithtabs.Controllers
{
    public class CustomerController : Controller
    {
        public readonly CustomerRepo _repo;
        public CustomerController()
        {
            _repo = new CustomerRepo();
        }
        public IActionResult Index()
        {
            _repo.Add();
            return View();
        }
    }
}
