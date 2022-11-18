using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MaxAgeRangeBadRequestException : Exception
    {
        public MaxAgeRangeBadRequestException(string message) : base(message) { }
    }
}
