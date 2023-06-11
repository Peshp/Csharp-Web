using Library.Models;

namespace Library.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookViewModel>> GetBooksAsync();

        public Task AddToMyCollection(string userId, int bookId);

        public Task<IEnumerable<BookViewModel>> GetCurrentUserBooksCollectionAsync(string userId);

        public Task<IEnumerable<CategoryFormModel>> GetAllCategories();

        public Task AddNewBook(BookFormModel formModel);

        public Task RemoveFromMyCollection(string userId, int bookId);

        public Task EditBookAsync(BookEditModel formModel, int bookId);

        public Task FindBookById(int id);
    }
}
