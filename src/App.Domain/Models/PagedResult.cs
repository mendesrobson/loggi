using System.Collections.Generic;

namespace App.Domain.Models
{
    public class PagedResult<TEntity>
    {
        public PagedResult(int offset, int limit, int total, IEnumerable<TEntity> items)
        {
            Offset = offset;
            Limit = limit;
            Total = total;
            Items = items;
        }

        public PagedResult(int offset, int limit, IEnumerable<TEntity> items)
            : this(offset, limit, 0, items)
        {
        }

        public int Offset { get; }

        public int Limit { get; }

        public int Total { get; set; }

        public IEnumerable<TEntity> Items { get; set; }
    }

}
