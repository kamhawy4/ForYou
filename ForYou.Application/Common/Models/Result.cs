using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Common.Models
{
    public class Result<T>
    {

        public bool IsSuccess { get; private set; }

        public string ErrorMessage { get; private set; }

        public T Value { get; private set; }

        private Result(bool success, string errorMessage, T value)
        {
            IsSuccess = success;
            ErrorMessage = errorMessage;
            Value = value;
        }

        public static Result<T> Success(T value) => new Result<T>(true, null, value);

        public static Result<T> Failure(string errorMessage) => new Result<T>(false, errorMessage, default);



    }
}
