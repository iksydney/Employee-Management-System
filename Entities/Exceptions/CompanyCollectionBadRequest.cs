using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CompanyCollectionBadRequest : MaxAgeRangeBadRequestException
    {
        public CompanyCollectionBadRequest() : base("Company selection sent from a client is null")
        {

        }
    }
}
