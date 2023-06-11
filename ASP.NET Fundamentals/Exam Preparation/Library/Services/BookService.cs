using Library.Data;
using Library.Data.Entities;
using Library.Interfaces;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewBook(BookFormModel formModel)
        {
            Book book = new Book()
            {
                Id = formModel.Id,
                Title = formModel.Title,
                Author = formModel.Author,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Rating = formModel.Rating,
                CategoryId = formModel.CategoryId
            };

            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task AddToMyCollection(string userId, int bookId)
        {
            // 1. Found the book with that id from context
            Book book = await context.Books
                .FirstOrDefaultAsync(b => b.Id == bookId);

            // 2. Check in USersBooks is that userId valid
            if(!book.UsersBooks.Any(b => b.CollectorId == userId))
            {
                // 3. Add book to that user
                book.UsersBooks.Add(new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = bookId
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task EditBookAsync(BookEditModel formModel, int bookId)
        {
            var book = await context.Books
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if(book != null)
            {
                book.Title = formModel.Title;
                book.Author = formModel.Author;
                book.Description = formModel.Description;
                book.ImageUrl = formModel.ImageUrl;
                book.Rating = formModel.Rating;
                book.CategoryId = formModel.CategoryId;
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryFormModel>> GetAllCategories()
        {
            var models = await context.Categories.ToArrayAsync();

            var categories = models
                .Select(c => new CategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return categories;
        }

        public async Task<IEnumerable<BookViewModel>> GetBooksAsync()
        {
            var models = await context.Books.Include(b => b.Category).ToArrayAsync();

            var books = models
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Rating = x.Rating,
                    Category = x.Category.Name
                });

            return books;
        }

        public async Task<IEnumerable<BookViewModel>> GetCurrentUserBooksCollectionAsync(string userId)
        {
            // 1. Get enetities from context.Books, include UsersBooks, Category
            // and find that userId
            var entities = await context.Books
                .Include(b => b.Category)
                .Include(b => b.UsersBooks)
                .Where(b => b.UsersBooks
                        .Any(ub => ub.CollectorId == userId))
                .ToArrayAsync();

            // 2.Get models and return
            var models = entities
                .Select(e => new BookViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Author = e.Author,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    Rating = e.Rating,
                    Category = e.Category.Name
                });

            return models;
        }

        public async Task RemoveFromMyCollection(string userId, int bookId)
        {
            var book = await context.Books
                .Include(b => b.UsersBooks)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            var entityToRemove = book.UsersBooks
                .FirstOrDefault(b => b.CollectorId == userId);

            if(entityToRemove != null)
            {
                book.UsersBooks.Remove(entityToRemove);
            }

            await context.SaveChangesAsync();
        }

        Task IBookService.FindBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
