using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCA.Infrastructure.RepositoryFramework;

namespace SmartCA.Model.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IList<Employee> GetConstructionAdministrators();
        IList<Employee> GetPrincipals();
    }
}
