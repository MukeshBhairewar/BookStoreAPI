using APIDemoProject.Data;
using APIDemoProject.Models;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Cryptography;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace APIDemoProject.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBookAsync()
        {
            //var records = await _context.Books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToListAsync();
            //return records;
            
            //Automapper
            var records= await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookIdAsync(int bookId)
        {
            //var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).FirstOrDefaultAsync();

            //return records;

            //Using Automapper
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);    

        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return (book.Id);
        }

        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(bookId);
            //if(book != null)
            //{
            //    book.Title = bookmodel.Title;
            //    book.Description = bookmodel.Description;

            //    await _context.SaveChangesAsync();
            //}
            var book = new Books()
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();


        }

        public async Task UpdateBookPatchAsync(int bookId, Microsoft.AspNetCore.JsonPatch.JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { Id = bookId };

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();
        }
    }
}
