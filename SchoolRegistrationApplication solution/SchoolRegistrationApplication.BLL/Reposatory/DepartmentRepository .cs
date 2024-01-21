using SchoolRegistrationApplication.BLL.Interfaces;
using SchoolRegistrationApplication.DAL.Context;
using SchoolRegistrationApplication.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistrationApplication.BLL.Reposatory
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentReposatory
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}