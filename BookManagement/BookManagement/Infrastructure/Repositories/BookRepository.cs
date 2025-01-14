﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID {id} not found");
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task UpdateAsync(Book book)
        {
            var bookExisting = await context.Books.FindAsync(book.Id);
            if (bookExisting != null)
            {
                context.Entry(bookExisting).CurrentValues.SetValues(book);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID {book.Id} not found");
            }
        }
    }
}
