using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.ComandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Guid>
    {
        private readonly IBookRepository repository;
        public UpdateBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await repository.GetByIdAsync(request.Id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.Id} not found");
            }
            book.Title = request.Title;
            book.Author = request.Author;
            book.ISBN = request.ISBN;
            book.PublicationDate = request.PublicationDate;

            await repository.UpdateAsync(book);
            return book.Id;

        }
    }
}
