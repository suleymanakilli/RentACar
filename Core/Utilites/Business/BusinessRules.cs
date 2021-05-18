using Core.Utilites.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.IsSuccessful)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
