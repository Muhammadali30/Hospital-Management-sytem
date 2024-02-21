using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Classes
{
    public class LaboratoryClass
    {
        public DataTable GetDepartments()
        {
            Database db=new Database();
            return db.Read("select * from Lab_Departments");
        }
    }
}
