using Library.Interfaces;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService service;

        public BookController(IBookService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var books = await service.GetBooksAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var models = await service.GetAllCategories();

            var model = new BookFormModel
            {
                Categories = models
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel model)
        {
            //1. Get valid categories
            var validCategories = await service.GetAllCategories();

            //2. Check is the valid categories is valid to current CategoryId
            if(!validCategories.Any(c => c.Id == model.CategoryId))
            {
                //2.1 If is not valid return error
                ModelState.AddModelError(nameof(model.CategoryId), "Invalid category Id");
            }
          
            if(ModelState.IsValid)
            {
                //3. Otherwise check modelstrate and return view
                model.Categories = validCategories;
                return View(model);
            }

            //4. In the end add book to the model and redirect to action all
            await service.AddNewBook(model);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var books = await service.GetCurrentUserBooksCollectionAsync(userid);
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            // 1. Get id from claim
            // 2. Try catch

            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await service.AddToMyCollection(userid, id);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Mine));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await service.RemoveFromMyCollection(userid, id);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Mine));

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookEditModel model)
        {
            var validCategories = await service.GetAllCategories();

            if (!validCategories.Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Invalid category Id");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = validCategories;
                return View(model);
            }

            try
            {
                await service.EditBookAsync(model, id);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Book");
        }
    }
}
