using Ghando.Service.Contracts;
using Ghando.Service.Contracts.Dto;
using Microsoft.EntityFrameworkCore;

namespace Ghando.PersistenceEF.Extensions;

public static class QueryableExtension
{
    private const int DefaultPageLimit = 10;
    private const int MaximumPageLimit = 50;

    public static async Task<PagedListResult<T>> ToPagedListAsync<T>(
        this IQueryable<T> query,
        PaginationDto pagination,
        CancellationToken cancellationToken = default
    )
    {
        pagination.PageLimit = pagination.PageLimit switch
        {
            0 => DefaultPageLimit,
            < 0 or > MaximumPageLimit => MaximumPageLimit,
            _ => pagination.PageLimit
        };

        pagination.PageIndex = Math.Max(pagination.PageIndex, 1);

        var pagedListDto = new PagedListResult<T>();

        pagedListDto.TotalItems = await query.CountAsync(cancellationToken);

        pagedListDto.TotalPages =
            (int)Math.Ceiling((double)pagedListDto.TotalItems /
                              pagination.PageLimit);

        pagedListDto.Items = await query
            .Skip((pagination.PageIndex - 1) * pagination.PageLimit)
            .Take(pagination.PageLimit)
            .ToListAsync(cancellationToken);

        return pagedListDto;
    }
}