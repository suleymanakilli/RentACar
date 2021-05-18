using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public class Result : IResult
    {
        public Result(bool isSuccessful, string message) : this(isSuccessful)
        {
            Message = message;
        }
        public Result(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }
        public bool IsSuccessful { get; }

        public string Message { get; }
    }
}
