using System;
using System.Collections.Generic;
using System.Linq;

namespace App.API.Models
{
    public class PagedResult<T> : Result<IEnumerable<T>>
    {
        public PagedResult(int offset, int limit, int total, IEnumerable<T> content)
            : base(content)
        {
            Offset = offset;
            Limit = limit;
            Total = total;
        }

        public PagedResult(int offset, int limit, IEnumerable<T> content)
            : this(offset, limit, -1, content)
        {
        }

        public int Offset { get; }

        public int Limit { get; }

        public int Total { get; set; }

        public int TotalContent { get { return Content?.Count() ?? -1; } }

        public PagedResult<NewEntityType> AlterContent<NewEntityType>(IEnumerable<NewEntityType> newContent)
        {
            var result = new PagedResult<NewEntityType>(this.Offset, this.Limit, this.Total, newContent);

            result.SetErrors(this.Errors);

            return result;
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual PagedResult<T> SetErrors(IDictionary<string, IEnumerable<string>> errors)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            base.SetErrors(errors);

            return this;
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual PagedResult<T> SetError(string name, params string[] errors)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            base.SetError(name, errors);

            return this;
        }
    }
}
