using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public interface IResult
    {
        bool IsSuccessful { get; }
        string Message { get; }
    }
}
