using SchoolRegistrationApplication.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistrationApplication.BLL.Interfaces
{
    public interface IDepartmentReposatory : IGenericRepository<Department>
    {
        // 5 actions ==> Get All , get , create ,  delete, update

    }
}
