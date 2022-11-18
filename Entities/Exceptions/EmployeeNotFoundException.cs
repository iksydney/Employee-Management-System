﻿using CompanyEmployees.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(Guid employeeId): base($"Employee with id: {employeeId} doesnt exist in the database.")
        {

        }
    }
}
