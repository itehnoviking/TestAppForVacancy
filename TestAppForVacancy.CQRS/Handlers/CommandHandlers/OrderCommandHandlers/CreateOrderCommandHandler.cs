using AutoMapper;
using MediatR;
using TestAppForVacancy.CQRS.Models.Commands.OrderCommands;
using TestAppForVacancy.Data;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.CQRS.Handlers.CommandHandlers.OrderCommandHandlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly TestAppForVacancyContext _database;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(TestAppForVacancyContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }


    public async Task<bool> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(command);

        await _database.AddAsync(order, cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);

        return true;
    }
}