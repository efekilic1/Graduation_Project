using System;
using System.Collections.Generic;

namespace Business.Configuration.Filters.Validation
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
