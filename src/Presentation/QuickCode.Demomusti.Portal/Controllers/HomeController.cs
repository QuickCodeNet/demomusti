using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using QuickCode.Demomusti.Portal.Helpers.Authorization;
using QuickCode.Demomusti.Common.Nswag.Clients.IdentityModuleApi.Contracts;

namespace QuickCode.Demomusti.Portal.Controllers
{
    [Permission("Dashboard")]
    public class HomeController : BaseController
    {
        public HomeController(ITableComboboxSettingsClient tableComboboxSettingsClient, IHttpContextAccessor httpContextAccessor, IMemoryCache cache) : base(tableComboboxSettingsClient, httpContextAccessor, cache)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}
