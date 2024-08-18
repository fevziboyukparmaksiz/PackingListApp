using Microsoft.EntityFrameworkCore;
using PackingListApp.Application.DTO;
using PackingListApp.Application.Queries;
using PackingListApp.Infrastructure.EF.Contexts;
using PackingListApp.Infrastructure.EF.Models;
using PackingListApp.Shared.Abstractions.Queries;

namespace PackingListApp.Infrastructure.EF.Queries.Handlers;
internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList,PackingListDto>
{
    private readonly DbSet<PackingListReadModel> _packingLists;

    public GetPackingListHandler(ReadDbContext dbContext)
    {
        _packingLists = dbContext.PackingLists;
    }


    public  Task<PackingListDto> HandleAsync(GetPackingList query)
    {
        return _packingLists
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}
