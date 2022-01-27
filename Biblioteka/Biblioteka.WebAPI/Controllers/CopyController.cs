using Biblioteka.Infrastructure.Commands;
using Biblioteka.Infrastructure.DTO;
using Biblioteka.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class CopyController : Controller
    {
        private readonly ICopyService _copyService;

        public CopyController(ICopyService CopyService)
        {
            _copyService = CopyService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _copyService.BrowseAll();
            return Json(z);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> BrowseCopies(string title)
        {
            IEnumerable<CopyDTO> Copys = await _copyService.BrowseAllByFilterAsync(title);
            return Json(Copys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCopy(int id)
        {
            var Copy = await _copyService.GetAsync(id);
            return Json(Copy);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCopy([FromBody] CreateCopy Copy)
        {
            await _copyService.AddAsync(Copy);
            return Created("", Copy);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditCopy([FromBody] UpdateCopy Copy, int id)
        {
            await _copyService.UpdateAsync(id, Copy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCopy(int id)
        {
            await _copyService.DelAsync(id);
            return NoContent();
        }
    }
}
