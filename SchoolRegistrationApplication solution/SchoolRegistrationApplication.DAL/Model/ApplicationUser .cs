using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistrationApplication.DAL.Model
{
    public class ApplicationUser : IdentityUser 
    {
        public string Fname { get; set; }
        public string Lname { get; set; }

        
    }
}

