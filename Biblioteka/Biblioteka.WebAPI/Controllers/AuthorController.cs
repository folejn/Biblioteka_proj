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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService AuthorService)
        {
            _authorService = AuthorService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _authorService.BrowseAll();
            return Json(z);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> BrowseAuthors(string lastName)
        {
            IEnumerable<AuthorDTO> Authors = await _authorService.BrowseAllByFilterAsync(lastName);
            return Json(Authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var Author = await _authorService.GetAsync(id);
            return Json(Author);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAuthor([FromBody] CreateAuthor Author)
        {
            await _authorService.AddAsync(Author);
            return Created("", Author);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditAuthor([FromBody] UpdateAuthor Author, int id)
        {
            await _authorService.UpdateAsync(id, Author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DelAsync(id);
            return NoContent();
        }
    }
}
