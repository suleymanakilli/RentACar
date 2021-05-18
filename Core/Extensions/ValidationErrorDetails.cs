﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    class ValidationErrorDetails:ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
