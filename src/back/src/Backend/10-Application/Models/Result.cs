using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Result : IResult
    {
        public double Duration { get; protected set; }

        public void SetDuration(double duration) => Duration = duration;

        public static Result Default() => new();
    }

    public class Result<T> : Result
    {
        public T? Data { get; set; }

        protected Result(T? data = default)
        {
            Data = data;
        }

        public static Result<T> From(T? data = default) => new(data);
    }
}
