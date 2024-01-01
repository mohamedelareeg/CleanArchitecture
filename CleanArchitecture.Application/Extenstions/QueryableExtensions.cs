using AutoMapper;
using CleanArchitecture.Application.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<TTarget>> ToPaginatedListAsync<TSource, TTarget>(this IQueryable<TSource> source, int pageNumber, int pageSize, IMapper mapper)
            where TSource : class
            where TTarget : class
        {
            if (source == null)
            {
                throw new Exception("Empty");
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await source.AsNoTracking().CountAsync();
            if (count == 0) return PaginatedResult<TTarget>.Success(new List<TTarget>(), count, pageNumber, pageSize);
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var mappedItems = items.Select(mapper.Map<TTarget>).ToList();
            return PaginatedResult<TTarget>.Success(mappedItems, count, pageNumber, pageSize);
        }

        public static async Task<PaginatedResult<TTarget>> ToPaginatedTableListAsync<TSource, TTarget>(this IQueryable<TSource> source, int start, int length, IMapper mapper)
            where TSource : class
            where TTarget : class
        {
            if (source == null)
            {
                throw new Exception("Empty");
            }

            start = start == 0 ? 1 : start;
            length = length == 0 ? 10 : length;
            int count = await source.AsNoTracking().CountAsync();
            if (count == 0) return PaginatedResult<TTarget>.Success(new List<TTarget>(), count, start, length);
            start = start <= 0 ? 1 : start;
            var items = await source.Skip(start).Take(length).ToListAsync();
            var mappedItems = items.Select(mapper.Map<TTarget>).ToList();
            return PaginatedResult<TTarget>.Success(mappedItems, count, start, length);
        }
    }
}
