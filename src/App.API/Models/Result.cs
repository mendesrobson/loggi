using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Models
{
    public class Result<T> : Result
    {
        public Result(T content)
        {
            Content = content;
        }

        public T Content { get; }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual Result<T> SetErrors(IDictionary<string, IEnumerable<string>> errors)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            base.SetErrors(errors);

            return this;
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual Result<T> SetError(string name, params string[] errors)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            base.SetError(name, errors);

            return this;
        }
    }

    public class Result
    {
        public Result()
        {
        }

        public static Result Empty => new Result();

        public static Result Default { get; set; }

        public IDictionary<string, IEnumerable<string>> Errors { get; protected set; } = new Dictionary<string, IEnumerable<string>>();

        public string SerializedErrors => HasErrors ? JsonConvert.SerializeObject(Errors) : string.Empty;

        public bool HasErrors => Errors?.Any() ?? false;

        public virtual Result SetErrors(IDictionary<string, IEnumerable<string>> errors)
        {
            Errors = errors;

            return this;
        }

        public virtual Result SetError(string name, params string[] errors)
        {
            Errors.Add(name, errors);

            return this;
        }
    }
}
