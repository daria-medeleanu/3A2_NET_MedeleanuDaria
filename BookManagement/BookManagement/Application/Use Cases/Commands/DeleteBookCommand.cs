using MediatR;
using Application.DTOs;



namespace Application.Use_Cases.Commands
{
    public class DeleteBookCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
