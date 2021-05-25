using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    class studentList
    {
        classEntities myDB = new classEntities();
        //public List<students> studentsArr { get; set; } = new List<students>();
        public List<students> allStudents()
        {
            return myDB.students.ToList();
        }
    }
}
