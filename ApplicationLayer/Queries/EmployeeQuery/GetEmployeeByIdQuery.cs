using DomainLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Queries.EmployeeQuery
{
    public class GetEmployeeByIdQuery : IRequest<Employee> {
        public int Id { get; set; }
    }
}
