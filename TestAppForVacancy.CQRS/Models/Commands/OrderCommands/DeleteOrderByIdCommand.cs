using MediatR;

namespace TestAppForVacancy.CQRS.Models.Commands.OrderCommands;

public class DeleteOrderByIdCommand : IRequest<bool>
{
    public DeleteOrderByIdCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}