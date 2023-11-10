using AutoMapper;
using MediatR;
using TestAppForVacancy.CQRS.Models.Commands.OrderCommands;
using TestAppForVacancy.Data;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.CQRS.Handlers.CommandHandlers.OrderCommandHandlers;

public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, bool>
{
    private readonly TestAppForVacancyContext _database;
    private readonly IMapper _mapper;

    public EditOrderCommandHandler(TestAppForVacancyContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<bool> Handle(EditOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request);

        _database.Orders.Update(order);

        await _database.SaveChangesAsync(cancellationToken: cancellationToken);

        return true;
    }
}