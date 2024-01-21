using SchoolRegistrationApplication.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistrationApplication.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //IEnumerable<Employee> address(string name);

        IEnumerable<Employee> Search(string name);

    }
}
