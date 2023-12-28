using APIDemoProject.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace APIDemoProject.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBookAsync();

        Task<BookModel> GetBookIdAsync(int bookId);

        Task<int> AddBookAsync(BookModel bookModel);

        Task UpdateBookAsync(int bookId, BookModel bookmodel);

        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookmodel);

        Task DeleteBookAsync(int bookId);
    }
}
