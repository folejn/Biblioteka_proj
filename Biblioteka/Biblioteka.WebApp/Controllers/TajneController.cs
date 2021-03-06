using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.WebApp.Controllers
{
    [Authorize(Roles = "wazny, zarzadca")]
    public class TajneController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }
    }
}
