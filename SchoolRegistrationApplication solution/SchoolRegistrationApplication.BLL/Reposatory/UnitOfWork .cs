using SchoolRegistrationApplication.BLL.Interfaces;
using SchoolRegistrationApplication.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistrationApplication.BLL.Reposatory
{
    public class UnitOfWork : IUnitofWork
    {
        //Automatic Property
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentReposatory DepartmentReposatory { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            EmployeeRepository = new EmployeeRepository(context);
            DepartmentReposatory = new DepartmentRepository(context);
        }

    }
}