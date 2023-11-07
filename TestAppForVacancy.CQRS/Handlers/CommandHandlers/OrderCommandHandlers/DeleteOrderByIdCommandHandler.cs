using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestAppForVacancy.CQRS.Models.Commands.OrderCommands;
using TestAppForVacancy.Data;

namespace TestAppForVacancy.CQRS.Handlers.CommandHandlers.OrderCommandHandlers;

public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, bool>
{
    private readonly TestAppForVacancyContext _database;

    public DeleteOrderByIdCommandHandler(TestAppForVacancyContext database)
    {
        _database = database;
    }

    public async Task<bool> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
    {
        var order = await _database.Orders
            .AsNoTracking()
            .Where(o => o.Id.Equals(command.Id))
            .Include(order => order.OrderItems)
            .FirstOrDefaultAsync(cancellationToken);

       _database.Orders.Remove(order);
       await _database.SaveChangesAsync(cancellationToken);

       return true;
    }
}