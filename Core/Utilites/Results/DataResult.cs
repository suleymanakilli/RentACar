using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool isSuccessful, string message) : base(isSuccessful, message)
        {
            Data = data;
        }
        public DataResult(T data, bool isSuccessful) : base(isSuccessful)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
